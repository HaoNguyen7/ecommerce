using backend_dotnet_r06_mall.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace backend_dotnet_r06_mall.Data
{
    public class BanHangContext : IdentityDbContext
    {
        public BanHangContext(DbContextOptions<BanHangContext> options) : base(options)
        {

        }

        public DbSet<CuaHang>? CuaHang { get; set; }
        public DbSet<DonHang>? DonHang { get; set; }
        public DbSet<HinhThucThanhToan>? HinhThucThanhToan { get; set; }
        public DbSet<KetQuaKiemTra>? KetQuaKiemTra { get; set; }
        public DbSet<KhachHang>? KhachHang { get; set; }
        public DbSet<LoaiSanPham>? LoaiSanPham { get; set; }
        public DbSet<NguoiGiaoHang>? NguoiGiaoHang { get; set; }
        public DbSet<SanPham>? SanPham { get; set; }
        public DbSet<ThongTinDiDuong>? ThongTinDiDuong { get; set; }
        public DbSet<TinhTrangDonHang>? TinhTrangDonHang { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>()
            .HasMany(p => p.SanPham)
            .WithMany(p => p.DonHang)
            .UsingEntity<DonHangSanPham>(
                j => j
                .HasOne(p => p.SanPham)
                .WithMany(t => t.DonHangSanPham)
                .HasForeignKey(pt => pt.SanPhamId),

                j => j
                .HasOne(pt => pt.DonHang)
                .WithMany(p => p.DonHangSanPham)
                .HasForeignKey(pt => pt.DonHangId),

                j =>
                {
                    j.HasKey(t => new { t.DonHangId, t.SanPhamId });
                }

            );
            base.OnModelCreating(modelBuilder);
        }

    }
}