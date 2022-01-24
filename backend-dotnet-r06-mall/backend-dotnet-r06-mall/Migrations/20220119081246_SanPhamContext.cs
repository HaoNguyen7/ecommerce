using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class SanPhamContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinDiDuong_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong");

            migrationBuilder.AlterColumn<Guid>(
                name: "NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HinhMinhHoa",
                table: "SanPham",
                type: "nvarchar(max)",
                maxLength: 2147483645,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinDiDuong_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong",
                column: "NguoiGiaoHangNguoiGiaoId",
                principalTable: "NguoiGiaoHang",
                principalColumn: "NguoiGiaoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinDiDuong_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong");

            migrationBuilder.DropColumn(
                name: "HinhMinhHoa",
                table: "SanPham");

            migrationBuilder.AlterColumn<Guid>(
                name: "NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinDiDuong_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong",
                column: "NguoiGiaoHangNguoiGiaoId",
                principalTable: "NguoiGiaoHang",
                principalColumn: "NguoiGiaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
