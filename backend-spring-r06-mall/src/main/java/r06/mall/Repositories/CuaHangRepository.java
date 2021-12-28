package r06.mall.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import r06.mall.Models.CuaHang;

@Repository
public interface CuaHangRepository extends JpaRepository<CuaHang, String> {
    @Query(value = "select SanPham.CuaHangId, CuaHang.TenCuaHang, SUM(SanPham.DonGia * DonHangSanPham.SoLuong) as DoanhThu, "
            + "SUM(DonHangSanPham.SoLuong) as SoLuong, Year(DonHang.ThoiGian) as Nam, Month(DonHang.ThoiGian) as Thang "
            + "from SanPham, DonHangSanPham, DonHang, CuaHang "
            + "where SanPham.SanPhamId = DonHangSanPham.SanPhamId and DonHang.DonHangId = DonHangSanPham.DonHangId and "
            + "DonHang.TinhTrangThanhToan = 1 and SanPham.CuaHangId = CuaHang.CuaHangId "
            + "group by SanPham.CuaHangId, CuaHang.TenCuaHang, DonHang.ThoiGian", nativeQuery = true)
    List<HoaHong> findAllHoaHong();

    @Query(value = "select SanPham.CuaHangId, CuaHang.TenCuaHang, SUM(SanPham.DonGia * DonHangSanPham.SoLuong) as DoanhThu, "
            + "SUM(DonHangSanPham.SoLuong) as SoLuong, Year(DonHang.ThoiGian) as Nam, Month(DonHang.ThoiGian) as Thang "
            + "from SanPham, DonHangSanPham, DonHang, CuaHang "
            + "where SanPham.SanPhamId = DonHangSanPham.SanPhamId and DonHang.DonHangId = DonHangSanPham.DonHangId and "
            + "DonHang.TinhTrangThanhToan = 1 and SanPham.CuaHangId = CuaHang.CuaHangId and Year(DonHang.ThoiGian) = ?1 and Month(DonHang.ThoiGian) = ?2 "
            + "group by SanPham.CuaHangId, CuaHang.TenCuaHang, DonHang.ThoiGian", nativeQuery = true)
    List<HoaHong> findHoaHongByNamAndThang(int nam, int thang);
}
