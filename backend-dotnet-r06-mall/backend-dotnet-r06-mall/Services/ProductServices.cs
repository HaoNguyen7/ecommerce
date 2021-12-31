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

namespace backend_dotnet_r06_mall.Services
{
    public class ProductServices
    {
        private readonly BanHangContext _context;


        public ProductServices(BanHangContext context)
        {
            _context = context;
        }

        public async Task<PagedList<SanPham>> GetProducts(ProductListRequest query)
        {
            var products = from s in _context.SanPham
                           select s;

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

            return await PagedList<SanPham>.CreateAsync(products.AsNoTracking(), query.pageIndex, query.pageSize);

        }
        public async Task<SanPham> GetProductDetail(Guid productId)
        {
            return await _context.SanPham.Include(o => o.CuaHang).Include(o => o.LoaiSanPham).AsNoTracking().FirstOrDefaultAsync(o => o.SanPhamId.Equals(productId));
        }
    }
}