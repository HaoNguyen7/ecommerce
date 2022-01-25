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
        private readonly BanHangContext _context;


        public ProductServices(BanHangContext context)
        {
            _context = context;
        }

        public async Task<List<SanPham>> GetProducts(ProductListRequest query)
        {
            var products = from s in _context.SanPham
                           select s;

            if (query.shopId is not null && !query.shopId.Equals(""))
            {
                products = products.Where(s => s.CuaHang.CuaHangId.Equals(new Guid(query.shopId)));
            }

            if (!String.IsNullOrEmpty(query.categoryId))
            {
                products = products.Where(s => s.LoaiSanPham.LoaiId.Equals(new Guid(query.categoryId)));
            }
            if (!String.IsNullOrEmpty(query.searchString))
            {
                products = products.Where(s => s.TenSanPham.Contains(query.searchString)
                    || s.LoaiSanPham.Ten.Contains(query.searchString));
            }

            switch (query.sortOrder)
            {
                case "price_desc":
                    products = products.OrderByDescending(s => s.DonGia);
                    break;
                case "price_asc":
                    products = products.OrderBy(s => s.DonGia);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(s => s.NgayDang);
                    break;
                case "date_asc":
                    products = products.OrderBy(s => s.NgayDang);
                    break;
                default:
                    products = products.OrderByDescending(s => s.NgayDang);
                    break;
            }

            var res = await products.Include(o => o.CuaHang).AsNoTracking().ToListAsync();
            return res;

        }
        public async Task<SanPham> GetProductDetail(Guid productId)
        {
            return await _context.SanPham.Include(o => o.CuaHang).Include(o => o.LoaiSanPham).AsNoTracking().FirstOrDefaultAsync(o => o.SanPhamId.Equals(productId));
        }

        public async Task<EntityEntry<SanPham>> CreateProduct(RegisterProductRequest request)
        {
            SanPham sanpham = new SanPham
            {
                SanPhamId = new Guid(),
                TenSanPham = request.TenSanPham,
                MoTa = request.MoTa,
                DonVi = request.DonVi,
                DonGia = request.DonGia,
                LoaiSanPham = _context.LoaiSanPham.FirstOrDefault(o => o.LoaiId == request.LoaiSanPham),
                TonKho = request.TonKho,
                CuaHang = _context.CuaHang.FirstOrDefault(o => o.CuaHangId == request.CuaHang),
                NgayDang = DateTime.Now,
                HinhMinhHoa = request.HinhMinhHoa,
                NguonGoc = request.NguonGoc
            };

            var createResult = await _context.SanPham.AddAsync(sanpham);
            await _context.SaveChangesAsync();
            return createResult;
        }

        public async Task<SanPham> UpdateProduct(UpdateProductRequest request)
        {
            SanPham product = _context.SanPham.Find(request.id);
            if (product == null)
            {
                return null;
            }
            if (!String.IsNullOrEmpty(request.TenSanPham))
            {
                product.TenSanPham = request.TenSanPham;
            }
            if (!String.IsNullOrEmpty(request.MoTa))
            {
                product.MoTa = request.MoTa;
            }
            if (request.TonKho > 0)
            {
                product.TonKho = request.TonKho;
            }
            if (request.DonVi != "")
            {
                product.DonVi = request.DonVi;
            }
            if (request.TonKho > 0)
            {
                product.DonGia = request.DonGia;
            }
            if (request.LoaiSanPham != Guid.Empty && _context.LoaiSanPham.FirstOrDefault(o => o.LoaiId == request.LoaiSanPham) != null)
            {
                product.LoaiSanPham = _context.LoaiSanPham.FirstOrDefault(o => o.LoaiId == request.LoaiSanPham);
            }
            if (request.HinhMinhHoa != "")
            {
                product.HinhMinhHoa = request.HinhMinhHoa;
            }

            if(request.NguonGoc != "") {
                product.NguonGoc = request.NguonGoc;
            }
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> RemoveProduct(RemoveProductRequest request)
        {
            SanPham product = _context.SanPham.Find(request.id);
            if (product == null)
            {
                return false;
            }

            _context.SanPham.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<LoaiSanPham>> getCategories()
        {
            return await _context.LoaiSanPham.AsNoTracking().ToListAsync();
        }
    }
}