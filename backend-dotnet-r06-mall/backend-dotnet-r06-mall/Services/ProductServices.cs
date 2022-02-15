using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace backend_dotnet_r06_mall.Services
{
    public class ProductServices
    {
        private readonly SaleContext _context;


        public ProductServices(SaleContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts(ProductListRequest query)
        {
            var products = from s in _context.Products
                           select s;

            if (query.shopId is not null && !query.shopId.Equals(""))
            {
                products = products.Where(s => s.Store.StoreId.Equals(new Guid(query.shopId)));
            }

            if (!String.IsNullOrEmpty(query.categoryId))
            {
                products = products.Where(s => s.Category.CategoryId.Equals(new Guid(query.categoryId)));
            }
            if (!String.IsNullOrEmpty(query.searchString))
            {
                products = products.Where(s => s.ProductName.Contains(query.searchString)
                    || s.Category.CategoryName.Contains(query.searchString));
            }

            //if (query.status > 0)
            //{
            //    products = products.Where(s => s.TinhTrang.Equals(query.status));
            //}

            switch (query.sortOrder)
            {
                case "price_desc":
                    products = products.OrderByDescending(s => s.UnitPrice);
                    break;
                case "price_asc":
                    products = products.OrderBy(s => s.UnitPrice);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(s => s.CreatedDate);
                    break;
                case "date_asc":
                    products = products.OrderBy(s => s.CreatedDate);
                    break;
                default:
                    products = products.OrderByDescending(s => s.CreatedDate);
                    break;
            }

            var res = await products.Include(o => o.Store).AsNoTracking().ToListAsync();
            return res;

        }
        public async Task<Product> GetProductDetail(Guid productId)
        {
            return await _context.Products.Include(o => o.Store).Include(o => o.Category).AsNoTracking().FirstOrDefaultAsync(o => o.ProductId.Equals(productId));
        }

        public async Task<EntityEntry<Product>> CreateProduct(RegisterProductRequest request)
        {
            Product sanpham = new Product
            {
                ProductName = request.TenSanPham,
                Description = request.MoTa,
                Unit = request.DonVi,
                UnitPrice = request.DonGia,
                Category = _context.Categories.FirstOrDefault(o => o.CategoryId == request.LoaiSanPham),
                InventoryNumber = request.TonKho,
                Store = _context.Stores.FirstOrDefault(o => o.StoreId == request.CuaHang),
                CreatedDate = DateTime.Now,
                Image = request.HinhMinhHoa,
                Origin = request.NguonGoc
            };

            var createResult = await _context.Products.AddAsync(sanpham);
            await _context.SaveChangesAsync();
            return createResult;
        }

        public async Task<Product> UpdateProduct(UpdateProductRequest request)
        {
            Product product = _context.Products.Find(request.id);
            if (product == null)
            {
                return null;
            }
            if (!String.IsNullOrEmpty(request.TenSanPham))
            {
                product.ProductName = request.TenSanPham;
            }
            if (!String.IsNullOrEmpty(request.MoTa))
            {
                product.Description = request.MoTa;
            }
            if (request.TonKho > 0)
            {
                product.InventoryNumber = request.TonKho;
            }
            if (request.DonVi != "")
            {
                product.Unit = request.DonVi;
            }
            if (request.TonKho > 0)
            {
                product.UnitPrice = request.DonGia;
            }
            if (request.LoaiSanPham > 0 && _context.Categories.FirstOrDefault(o => o.CategoryId == request.LoaiSanPham) != null)
            {
                product.Category = _context.Categories.FirstOrDefault(o => o.CategoryId == request.LoaiSanPham);
            }
            if (request.HinhMinhHoa != "")
            {
                product.Image = request.HinhMinhHoa;
            }

            if(request.NguonGoc != "") {
                product.Origin = request.NguonGoc;
            }
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> RemoveProduct(RemoveProductRequest request)
        {
            Product product = _context.Products.Find(request.id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> getCategories()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
    }
}