using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class UpdateCuaHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "KinhDo",
                table: "CuaHang",
                type: "decimal(18,10)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ViDo",
                table: "CuaHang",
                type: "decimal(18,10)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KinhDo",
                table: "CuaHang");

            migrationBuilder.DropColumn(
                name: "ViDo",
                table: "CuaHang");
        }
    }
}
