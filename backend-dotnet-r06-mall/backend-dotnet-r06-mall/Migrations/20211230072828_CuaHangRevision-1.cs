using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class CuaHangRevision1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "CuaHang",
                type: "nvarchar(max)",
                maxLength: 2147483645,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSoThue",
                table: "CuaHang",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "CuaHang");

            migrationBuilder.DropColumn(
                name: "MaSoThue",
                table: "CuaHang");
        }
    }
}
