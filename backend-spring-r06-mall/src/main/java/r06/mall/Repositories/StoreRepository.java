package r06.mall.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import r06.mall.Models.CuaHang;

@Repository
public interface StoreRepository extends JpaRepository<CuaHang, String> {
        @Query(value = "select SanPham.CuaHangId, CuaHang.TenCuaHang, SUM(SanPham.DonGia * DonHangSanPham.SoLuong) as DoanhThu, "
                        + "SUM(DonHangSanPham.SoLuong) as SoLuong, Year(DonHang.ThoiGian) as Nam, Month(DonHang.ThoiGian) as Thang "
                        + "from SanPham, DonHangSanPham, DonHang, CuaHang "
                        + "where SanPham.SanPhamId = DonHangSanPham.SanPhamId and DonHang.DonHangId = DonHangSanPham.DonHangId and "
                        + "DonHang.TinhTrangThanhToan = 1 and SanPham.CuaHangId = CuaHang.CuaHangId "
                        + "group by SanPham.CuaHangId, CuaHang.TenCuaHang, DonHang.ThoiGian", nativeQuery = true)
        List<Commission> findAllHoaHong();

        @Query(value = "select SanPham.CuaHangId, CuaHang.TenCuaHang, SUM(SanPham.DonGia * DonHangSanPham.SoLuong) as DoanhThu, "
                        + "SUM(DonHangSanPham.SoLuong) as SoLuong, Year(DonHang.ThoiGian) as Nam, Month(DonHang.ThoiGian) as Thang "
                        + "from SanPham, DonHangSanPham, DonHang, CuaHang "
                        + "where SanPham.SanPhamId = DonHangSanPham.SanPhamId and DonHang.DonHangId = DonHangSanPham.DonHangId and "
                        + "DonHang.TinhTrangThanhToan = 1 and SanPham.CuaHangId = CuaHang.CuaHangId and Year(DonHang.ThoiGian) = ?1 and Month(DonHang.ThoiGian) = ?2 "
                        + "group by SanPham.CuaHangId, CuaHang.TenCuaHang, DonHang.ThoiGian", nativeQuery = true)
        List<Commission> findHoaHongByNamAndThang(int nam, int thang);

        @Query(value = "select sp.SanPhamId, sp.TenSanPham, SUM(dhsp.SoLuong) SoLuong, sp.DonGia "
                +"from (DonHang dh join DonHangSanPham dhsp on dh.DonHangId=dhsp.DonHangId) "
                +"join (CuaHang ch join SanPham sp on ch.CuaHangId = sp.CuaHangId) on sp.SanPhamId = dhsp.SanPhamId "
                +"where MONTH(ThoiGian)>= ?1 and MONTH(thoigian) <= ?2 and YEAR(thoigian) = ?3 and ch.CuaHangId= ?4 "
                + "Group by sp.SanPhamId, sp.TenSanPham,  sp.DonGia", nativeQuery = true)
        List<Report> findReportByQuarter(int startMonth, int endMonth, int nam, String id);
}
