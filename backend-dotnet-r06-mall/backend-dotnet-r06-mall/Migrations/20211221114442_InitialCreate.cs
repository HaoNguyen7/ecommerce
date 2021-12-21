using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuaHang_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenCuaHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DanhGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STK = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHang_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucThanhToan_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHTTT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucThanhToan_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    STK = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Vung = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangDonHang_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenTinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangDonHang_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TonKho = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    DonVi = table.Column<int>(type: "int", nullable: false),
                    LoaiSanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CuaHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham__CuaHang__CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHang_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPham__LoaiSanPham__LoaiSanPhamId",
                        column: x => x.LoaiSanPhamId,
                        principalTable: "LoaiSanPham_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NguoiGiaoHang_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNguoiGiaoHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    STK = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VungHoatDong = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrangDonHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiGiaoHang_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiGiaoHang__TinhTrangDonHang__TinhTrangDonHangId",
                        column: x => x.TinhTrangDonHangId,
                        principalTable: "TinhTrangDonHang_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonHang_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrangThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    DanhGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    HinhThucThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NguoiGiaoHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TinhTrangDonHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonHang__HinhThucThanhToan__HinhThucThanhToanId",
                        column: x => x.HinhThucThanhToanId,
                        principalTable: "HinhThucThanhToan_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonHang__KhachHang__KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonHang__NguoiGiaoHang__NguoiGiaoHangId",
                        column: x => x.NguoiGiaoHangId,
                        principalTable: "NguoiGiaoHang_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonHang__TinhTrangDonHang__TinhTrangDonHangId",
                        column: x => x.TinhTrangDonHangId,
                        principalTable: "TinhTrangDonHang_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KetQuaKiemTra_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KetQua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayKiemTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiGiaoHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaKiemTra_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KetQuaKiemTra__NguoiGiaoHang__NguoiGiaoHangId",
                        column: x => x.NguoiGiaoHangId,
                        principalTable: "NguoiGiaoHang_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinDiDuong_",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiGiaoHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinDiDuong_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongTinDiDuong__NguoiGiaoHang__NguoiGiaoHangId",
                        column: x => x.NguoiGiaoHangId,
                        principalTable: "NguoiGiaoHang_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHang__HinhThucThanhToanId",
                table: "DonHang_",
                column: "HinhThucThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang__KhachHangId",
                table: "DonHang_",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang__NguoiGiaoHangId",
                table: "DonHang_",
                column: "NguoiGiaoHangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang__TinhTrangDonHangId",
                table: "DonHang_",
                column: "TinhTrangDonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaKiemTra__NguoiGiaoHangId",
                table: "KetQuaKiemTra_",
                column: "NguoiGiaoHangId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiGiaoHang__TinhTrangDonHangId",
                table: "NguoiGiaoHang_",
                column: "TinhTrangDonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham__CuaHangId",
                table: "SanPham_",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham__LoaiSanPhamId",
                table: "SanPham_",
                column: "LoaiSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinDiDuong__NguoiGiaoHangId",
                table: "ThongTinDiDuong_",
                column: "NguoiGiaoHangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHang_");

            migrationBuilder.DropTable(
                name: "KetQuaKiemTra_");

            migrationBuilder.DropTable(
                name: "SanPham_");

            migrationBuilder.DropTable(
                name: "ThongTinDiDuong_");

            migrationBuilder.DropTable(
                name: "HinhThucThanhToan_");

            migrationBuilder.DropTable(
                name: "KhachHang_");

            migrationBuilder.DropTable(
                name: "CuaHang_");

            migrationBuilder.DropTable(
                name: "LoaiSanPham_");

            migrationBuilder.DropTable(
                name: "NguoiGiaoHang_");

            migrationBuilder.DropTable(
                name: "TinhTrangDonHang_");
        }
    }
}
