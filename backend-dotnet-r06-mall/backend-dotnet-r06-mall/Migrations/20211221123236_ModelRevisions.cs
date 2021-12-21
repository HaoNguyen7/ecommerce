using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class ModelRevisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang__HinhThucThanhToan__HinhThucThanhToanId",
                table: "DonHang_");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang__KhachHang__KhachHangId",
                table: "DonHang_");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang__NguoiGiaoHang__NguoiGiaoHangId",
                table: "DonHang_");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang__TinhTrangDonHang__TinhTrangDonHangId",
                table: "DonHang_");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaKiemTra__NguoiGiaoHang__NguoiGiaoHangId",
                table: "KetQuaKiemTra_");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiGiaoHang__TinhTrangDonHang__TinhTrangDonHangId",
                table: "NguoiGiaoHang_");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham__CuaHang__CuaHangId",
                table: "SanPham_");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham__LoaiSanPham__LoaiSanPhamId",
                table: "SanPham_");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinDiDuong__NguoiGiaoHang__NguoiGiaoHangId",
                table: "ThongTinDiDuong_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TinhTrangDonHang_",
                table: "TinhTrangDonHang_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThongTinDiDuong_",
                table: "ThongTinDiDuong_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SanPham_",
                table: "SanPham_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NguoiGiaoHang_",
                table: "NguoiGiaoHang_");

            migrationBuilder.DropIndex(
                name: "IX_NguoiGiaoHang__TinhTrangDonHangId",
                table: "NguoiGiaoHang_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiSanPham_",
                table: "LoaiSanPham_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KhachHang_",
                table: "KhachHang_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KetQuaKiemTra_",
                table: "KetQuaKiemTra_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HinhThucThanhToan_",
                table: "HinhThucThanhToan_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonHang_",
                table: "DonHang_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuaHang_",
                table: "CuaHang_");

            migrationBuilder.DropColumn(
                name: "TinhTrangDonHangId",
                table: "NguoiGiaoHang_");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "KhachHang_");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "CuaHang_");

            migrationBuilder.RenameTable(
                name: "TinhTrangDonHang_",
                newName: "TinhTrangDonHang");

            migrationBuilder.RenameTable(
                name: "ThongTinDiDuong_",
                newName: "ThongTinDiDuong");

            migrationBuilder.RenameTable(
                name: "SanPham_",
                newName: "SanPham");

            migrationBuilder.RenameTable(
                name: "NguoiGiaoHang_",
                newName: "NguoiGiaoHang");

            migrationBuilder.RenameTable(
                name: "LoaiSanPham_",
                newName: "LoaiSanPham");

            migrationBuilder.RenameTable(
                name: "KhachHang_",
                newName: "KhachHang");

            migrationBuilder.RenameTable(
                name: "KetQuaKiemTra_",
                newName: "KetQuaKiemTra");

            migrationBuilder.RenameTable(
                name: "HinhThucThanhToan_",
                newName: "HinhThucThanhToan");

            migrationBuilder.RenameTable(
                name: "DonHang_",
                newName: "DonHang");

            migrationBuilder.RenameTable(
                name: "CuaHang_",
                newName: "CuaHang");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinDiDuong__NguoiGiaoHangId",
                table: "ThongTinDiDuong",
                newName: "IX_ThongTinDiDuong_NguoiGiaoHangId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham__LoaiSanPhamId",
                table: "SanPham",
                newName: "IX_SanPham_LoaiSanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham__CuaHangId",
                table: "SanPham",
                newName: "IX_SanPham_CuaHangId");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuaKiemTra__NguoiGiaoHangId",
                table: "KetQuaKiemTra",
                newName: "IX_KetQuaKiemTra_NguoiGiaoHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang__TinhTrangDonHangId",
                table: "DonHang",
                newName: "IX_DonHang_TinhTrangDonHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang__NguoiGiaoHangId",
                table: "DonHang",
                newName: "IX_DonHang_NguoiGiaoHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang__KhachHangId",
                table: "DonHang",
                newName: "IX_DonHang_KhachHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang__HinhThucThanhToanId",
                table: "DonHang",
                newName: "IX_DonHang_HinhThucThanhToanId");

            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "NguoiGiaoHang",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "KhachHang",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuong",
                table: "DonHang",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "CuaHang",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TinhTrangDonHang",
                table: "TinhTrangDonHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThongTinDiDuong",
                table: "ThongTinDiDuong",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NguoiGiaoHang",
                table: "NguoiGiaoHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiSanPham",
                table: "LoaiSanPham",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhachHang",
                table: "KhachHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KetQuaKiemTra",
                table: "KetQuaKiemTra",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HinhThucThanhToan",
                table: "HinhThucThanhToan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonHang",
                table: "DonHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuaHang",
                table: "CuaHang",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DonHangSanPham",
                columns: table => new
                {
                    DonHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangSanPham", x => new { x.DonHangId, x.SanPhamId });
                    table.ForeignKey(
                        name: "FK_DonHangSanPham_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangSanPham_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHangSanPham_SanPhamId",
                table: "DonHangSanPham",
                column: "SanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_HinhThucThanhToan_HinhThucThanhToanId",
                table: "DonHang",
                column: "HinhThucThanhToanId",
                principalTable: "HinhThucThanhToan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangId",
                table: "DonHang",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_NguoiGiaoHang_NguoiGiaoHangId",
                table: "DonHang",
                column: "NguoiGiaoHangId",
                principalTable: "NguoiGiaoHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_TinhTrangDonHang_TinhTrangDonHangId",
                table: "DonHang",
                column: "TinhTrangDonHangId",
                principalTable: "TinhTrangDonHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaKiemTra_NguoiGiaoHang_NguoiGiaoHangId",
                table: "KetQuaKiemTra",
                column: "NguoiGiaoHangId",
                principalTable: "NguoiGiaoHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_CuaHang_CuaHangId",
                table: "SanPham",
                column: "CuaHangId",
                principalTable: "CuaHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_LoaiSanPham_LoaiSanPhamId",
                table: "SanPham",
                column: "LoaiSanPhamId",
                principalTable: "LoaiSanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinDiDuong_NguoiGiaoHang_NguoiGiaoHangId",
                table: "ThongTinDiDuong",
                column: "NguoiGiaoHangId",
                principalTable: "NguoiGiaoHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_HinhThucThanhToan_HinhThucThanhToanId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_NguoiGiaoHang_NguoiGiaoHangId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_TinhTrangDonHang_TinhTrangDonHangId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaKiemTra_NguoiGiaoHang_NguoiGiaoHangId",
                table: "KetQuaKiemTra");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_CuaHang_CuaHangId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_LoaiSanPham_LoaiSanPhamId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinDiDuong_NguoiGiaoHang_NguoiGiaoHangId",
                table: "ThongTinDiDuong");

            migrationBuilder.DropTable(
                name: "DonHangSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TinhTrangDonHang",
                table: "TinhTrangDonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThongTinDiDuong",
                table: "ThongTinDiDuong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NguoiGiaoHang",
                table: "NguoiGiaoHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiSanPham",
                table: "LoaiSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KhachHang",
                table: "KhachHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KetQuaKiemTra",
                table: "KetQuaKiemTra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HinhThucThanhToan",
                table: "HinhThucThanhToan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonHang",
                table: "DonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuaHang",
                table: "CuaHang");

            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "CuaHang");

            migrationBuilder.RenameTable(
                name: "TinhTrangDonHang",
                newName: "TinhTrangDonHang_");

            migrationBuilder.RenameTable(
                name: "ThongTinDiDuong",
                newName: "ThongTinDiDuong_");

            migrationBuilder.RenameTable(
                name: "SanPham",
                newName: "SanPham_");

            migrationBuilder.RenameTable(
                name: "NguoiGiaoHang",
                newName: "NguoiGiaoHang_");

            migrationBuilder.RenameTable(
                name: "LoaiSanPham",
                newName: "LoaiSanPham_");

            migrationBuilder.RenameTable(
                name: "KhachHang",
                newName: "KhachHang_");

            migrationBuilder.RenameTable(
                name: "KetQuaKiemTra",
                newName: "KetQuaKiemTra_");

            migrationBuilder.RenameTable(
                name: "HinhThucThanhToan",
                newName: "HinhThucThanhToan_");

            migrationBuilder.RenameTable(
                name: "DonHang",
                newName: "DonHang_");

            migrationBuilder.RenameTable(
                name: "CuaHang",
                newName: "CuaHang_");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinDiDuong_NguoiGiaoHangId",
                table: "ThongTinDiDuong_",
                newName: "IX_ThongTinDiDuong__NguoiGiaoHangId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_LoaiSanPhamId",
                table: "SanPham_",
                newName: "IX_SanPham__LoaiSanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_CuaHangId",
                table: "SanPham_",
                newName: "IX_SanPham__CuaHangId");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuaKiemTra_NguoiGiaoHangId",
                table: "KetQuaKiemTra_",
                newName: "IX_KetQuaKiemTra__NguoiGiaoHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_TinhTrangDonHangId",
                table: "DonHang_",
                newName: "IX_DonHang__TinhTrangDonHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_NguoiGiaoHangId",
                table: "DonHang_",
                newName: "IX_DonHang__NguoiGiaoHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_KhachHangId",
                table: "DonHang_",
                newName: "IX_DonHang__KhachHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_HinhThucThanhToanId",
                table: "DonHang_",
                newName: "IX_DonHang__HinhThucThanhToanId");

            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "NguoiGiaoHang_",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TinhTrangDonHangId",
                table: "NguoiGiaoHang_",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "KhachHang_",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuong",
                table: "DonHang_",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "CuaHang_",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TinhTrangDonHang_",
                table: "TinhTrangDonHang_",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThongTinDiDuong_",
                table: "ThongTinDiDuong_",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanPham_",
                table: "SanPham_",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NguoiGiaoHang_",
                table: "NguoiGiaoHang_",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiSanPham_",
                table: "LoaiSanPham_",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhachHang_",
                table: "KhachHang_",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KetQuaKiemTra_",
                table: "KetQuaKiemTra_",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HinhThucThanhToan_",
                table: "HinhThucThanhToan_",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonHang_",
                table: "DonHang_",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuaHang_",
                table: "CuaHang_",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiGiaoHang__TinhTrangDonHangId",
                table: "NguoiGiaoHang_",
                column: "TinhTrangDonHangId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang__HinhThucThanhToan__HinhThucThanhToanId",
                table: "DonHang_",
                column: "HinhThucThanhToanId",
                principalTable: "HinhThucThanhToan_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang__KhachHang__KhachHangId",
                table: "DonHang_",
                column: "KhachHangId",
                principalTable: "KhachHang_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang__NguoiGiaoHang__NguoiGiaoHangId",
                table: "DonHang_",
                column: "NguoiGiaoHangId",
                principalTable: "NguoiGiaoHang_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang__TinhTrangDonHang__TinhTrangDonHangId",
                table: "DonHang_",
                column: "TinhTrangDonHangId",
                principalTable: "TinhTrangDonHang_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaKiemTra__NguoiGiaoHang__NguoiGiaoHangId",
                table: "KetQuaKiemTra_",
                column: "NguoiGiaoHangId",
                principalTable: "NguoiGiaoHang_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiGiaoHang__TinhTrangDonHang__TinhTrangDonHangId",
                table: "NguoiGiaoHang_",
                column: "TinhTrangDonHangId",
                principalTable: "TinhTrangDonHang_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham__CuaHang__CuaHangId",
                table: "SanPham_",
                column: "CuaHangId",
                principalTable: "CuaHang_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham__LoaiSanPham__LoaiSanPhamId",
                table: "SanPham_",
                column: "LoaiSanPhamId",
                principalTable: "LoaiSanPham_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinDiDuong__NguoiGiaoHang__NguoiGiaoHangId",
                table: "ThongTinDiDuong_",
                column: "NguoiGiaoHangId",
                principalTable: "NguoiGiaoHang_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
