using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class CuaHangContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nguonGoc",
                table: "SanPham",
                type: "nvarchar(max)",
                maxLength: 2147483645,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GiayPhepKinhDoanh",
                table: "CuaHang",
                type: "nvarchar(max)",
                maxLength: 2147483645,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nguonGoc",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "GiayPhepKinhDoanh",
                table: "CuaHang");
        }
    }
}
