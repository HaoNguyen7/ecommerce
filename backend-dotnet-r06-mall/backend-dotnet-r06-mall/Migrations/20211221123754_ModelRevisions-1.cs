using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class ModelRevisions1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CuaHang",
                newName: "CuaHangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CuaHangId",
                table: "CuaHang",
                newName: "Id");
        }
    }
}
