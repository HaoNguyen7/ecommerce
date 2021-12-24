using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class addProductDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDang",
                table: "SanPham",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayDang",
                table: "SanPham");
        }
    }
}
