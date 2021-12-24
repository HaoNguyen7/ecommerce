using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class updateDonHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_TinhTrangDonHang_TinhTrangDonHangTTDHId",
                table: "DonHang");

            migrationBuilder.DropIndex(
                name: "IX_DonHang_TinhTrangDonHangTTDHId",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "TinhTrangDonHangTTDHId",
                table: "DonHang");

            migrationBuilder.AddColumn<Guid>(
                name: "DonHangId",
                table: "TinhTrangDonHang",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "TinhTrangDonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayThucHien",
                table: "TinhTrangDonHang",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_TinhTrangDonHang_DonHangId",
                table: "TinhTrangDonHang",
                column: "DonHangId");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhTrangDonHang_DonHang_DonHangId",
                table: "TinhTrangDonHang",
                column: "DonHangId",
                principalTable: "DonHang",
                principalColumn: "DonHangId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TinhTrangDonHang_DonHang_DonHangId",
                table: "TinhTrangDonHang");

            migrationBuilder.DropIndex(
                name: "IX_TinhTrangDonHang_DonHangId",
                table: "TinhTrangDonHang");

            migrationBuilder.DropColumn(
                name: "DonHangId",
                table: "TinhTrangDonHang");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "TinhTrangDonHang");

            migrationBuilder.DropColumn(
                name: "NgayThucHien",
                table: "TinhTrangDonHang");

            migrationBuilder.AddColumn<Guid>(
                name: "TinhTrangDonHangTTDHId",
                table: "DonHang",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_TinhTrangDonHangTTDHId",
                table: "DonHang",
                column: "TinhTrangDonHangTTDHId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_TinhTrangDonHang_TinhTrangDonHangTTDHId",
                table: "DonHang",
                column: "TinhTrangDonHangTTDHId",
                principalTable: "TinhTrangDonHang",
                principalColumn: "TTDHId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
