using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dotnet_r06_mall.Migrations
{
    public partial class ModelRevisions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_HinhThucThanhToan_HinhThucThanhToanId",
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
                name: "FK_SanPham_LoaiSanPham_LoaiSanPhamId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinDiDuong_NguoiGiaoHang_NguoiGiaoHangId",
                table: "ThongTinDiDuong");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TinhTrangDonHang",
                newName: "TTDHId");

            migrationBuilder.RenameColumn(
                name: "NguoiGiaoHangId",
                table: "ThongTinDiDuong",
                newName: "NguoiGiaoHangNguoiGiaoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ThongTinDiDuong",
                newName: "TTTDId");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinDiDuong_NguoiGiaoHangId",
                table: "ThongTinDiDuong",
                newName: "IX_ThongTinDiDuong_NguoiGiaoHangNguoiGiaoId");

            migrationBuilder.RenameColumn(
                name: "LoaiSanPhamId",
                table: "SanPham",
                newName: "LoaiSanPhamLoaiId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SanPham",
                newName: "SanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_LoaiSanPhamId",
                table: "SanPham",
                newName: "IX_SanPham_LoaiSanPhamLoaiId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NguoiGiaoHang",
                newName: "NguoiGiaoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoaiSanPham",
                newName: "LoaiId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "KhachHang",
                newName: "KhachHangId");

            migrationBuilder.RenameColumn(
                name: "NguoiGiaoHangId",
                table: "KetQuaKiemTra",
                newName: "NguoiGiaoHangNguoiGiaoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "KetQuaKiemTra",
                newName: "KetQuaId");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuaKiemTra_NguoiGiaoHangId",
                table: "KetQuaKiemTra",
                newName: "IX_KetQuaKiemTra_NguoiGiaoHangNguoiGiaoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HinhThucThanhToan",
                newName: "HinhThucId");

            migrationBuilder.RenameColumn(
                name: "TinhTrangDonHangId",
                table: "DonHang",
                newName: "TinhTrangDonHangTTDHId");

            migrationBuilder.RenameColumn(
                name: "NguoiGiaoHangId",
                table: "DonHang",
                newName: "NguoiGiaoHangNguoiGiaoId");

            migrationBuilder.RenameColumn(
                name: "HinhThucThanhToanId",
                table: "DonHang",
                newName: "HinhThucThanhToanHinhThucId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DonHang",
                newName: "DonHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_TinhTrangDonHangId",
                table: "DonHang",
                newName: "IX_DonHang_TinhTrangDonHangTTDHId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_NguoiGiaoHangId",
                table: "DonHang",
                newName: "IX_DonHang_NguoiGiaoHangNguoiGiaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_HinhThucThanhToanId",
                table: "DonHang",
                newName: "IX_DonHang_HinhThucThanhToanHinhThucId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_HinhThucThanhToan_HinhThucThanhToanHinhThucId",
                table: "DonHang",
                column: "HinhThucThanhToanHinhThucId",
                principalTable: "HinhThucThanhToan",
                principalColumn: "HinhThucId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "DonHang",
                column: "NguoiGiaoHangNguoiGiaoId",
                principalTable: "NguoiGiaoHang",
                principalColumn: "NguoiGiaoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_TinhTrangDonHang_TinhTrangDonHangTTDHId",
                table: "DonHang",
                column: "TinhTrangDonHangTTDHId",
                principalTable: "TinhTrangDonHang",
                principalColumn: "TTDHId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaKiemTra_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "KetQuaKiemTra",
                column: "NguoiGiaoHangNguoiGiaoId",
                principalTable: "NguoiGiaoHang",
                principalColumn: "NguoiGiaoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_LoaiSanPham_LoaiSanPhamLoaiId",
                table: "SanPham",
                column: "LoaiSanPhamLoaiId",
                principalTable: "LoaiSanPham",
                principalColumn: "LoaiId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinDiDuong_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong",
                column: "NguoiGiaoHangNguoiGiaoId",
                principalTable: "NguoiGiaoHang",
                principalColumn: "NguoiGiaoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_HinhThucThanhToan_HinhThucThanhToanHinhThucId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_TinhTrangDonHang_TinhTrangDonHangTTDHId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaKiemTra_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "KetQuaKiemTra");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_LoaiSanPham_LoaiSanPhamLoaiId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinDiDuong_NguoiGiaoHang_NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong");

            migrationBuilder.RenameColumn(
                name: "TTDHId",
                table: "TinhTrangDonHang",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong",
                newName: "NguoiGiaoHangId");

            migrationBuilder.RenameColumn(
                name: "TTTDId",
                table: "ThongTinDiDuong",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinDiDuong_NguoiGiaoHangNguoiGiaoId",
                table: "ThongTinDiDuong",
                newName: "IX_ThongTinDiDuong_NguoiGiaoHangId");

            migrationBuilder.RenameColumn(
                name: "LoaiSanPhamLoaiId",
                table: "SanPham",
                newName: "LoaiSanPhamId");

            migrationBuilder.RenameColumn(
                name: "SanPhamId",
                table: "SanPham",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_LoaiSanPhamLoaiId",
                table: "SanPham",
                newName: "IX_SanPham_LoaiSanPhamId");

            migrationBuilder.RenameColumn(
                name: "NguoiGiaoId",
                table: "NguoiGiaoHang",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LoaiId",
                table: "LoaiSanPham",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "KhachHangId",
                table: "KhachHang",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NguoiGiaoHangNguoiGiaoId",
                table: "KetQuaKiemTra",
                newName: "NguoiGiaoHangId");

            migrationBuilder.RenameColumn(
                name: "KetQuaId",
                table: "KetQuaKiemTra",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuaKiemTra_NguoiGiaoHangNguoiGiaoId",
                table: "KetQuaKiemTra",
                newName: "IX_KetQuaKiemTra_NguoiGiaoHangId");

            migrationBuilder.RenameColumn(
                name: "HinhThucId",
                table: "HinhThucThanhToan",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TinhTrangDonHangTTDHId",
                table: "DonHang",
                newName: "TinhTrangDonHangId");

            migrationBuilder.RenameColumn(
                name: "NguoiGiaoHangNguoiGiaoId",
                table: "DonHang",
                newName: "NguoiGiaoHangId");

            migrationBuilder.RenameColumn(
                name: "HinhThucThanhToanHinhThucId",
                table: "DonHang",
                newName: "HinhThucThanhToanId");

            migrationBuilder.RenameColumn(
                name: "DonHangId",
                table: "DonHang",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_TinhTrangDonHangTTDHId",
                table: "DonHang",
                newName: "IX_DonHang_TinhTrangDonHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_NguoiGiaoHangNguoiGiaoId",
                table: "DonHang",
                newName: "IX_DonHang_NguoiGiaoHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_HinhThucThanhToanHinhThucId",
                table: "DonHang",
                newName: "IX_DonHang_HinhThucThanhToanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_HinhThucThanhToan_HinhThucThanhToanId",
                table: "DonHang",
                column: "HinhThucThanhToanId",
                principalTable: "HinhThucThanhToan",
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
    }
}
