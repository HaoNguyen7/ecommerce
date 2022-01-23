package r06.mall.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import r06.mall.Models.DonHangSanPham;

@Repository
public interface ImportantItemsRepository extends JpaRepository<DonHangSanPham, String> {
    @Query(value = "select top 10 dhsp.sanPhamId, sp.TenSanPham, SUM(dhsp.SoLuong) as SoLuong"
    + " from DonHangSanPham dhsp join SanPham sp on dhsp.sanPhamId = sp.sanPhamId"
    + " group by dhsp.sanPhamId, sp.TenSanPham"
    + " order by SoLuong desc", nativeQuery = true)
        List<Item> getImportantItems();
}
/*
@Query(value = "select SanPham.CuaHangId, CuaHang.TenCuaHang, SUM(SanPham.DonGia * DonHangSanPham.SoLuong) as DoanhThu, "
                        + "SUM(DonHangSanPham.SoLuong) as SoLuong, Year(DonHang.ThoiGian) as Nam, Month(DonHang.ThoiGian) as Thang "
                        + "from SanPham, DonHangSanPham, DonHang, CuaHang "
                        + "where SanPham.SanPhamId = DonHangSanPham.SanPhamId and DonHang.DonHangId = DonHangSanPham.DonHangId and "
                        + "DonHang.TinhTrangThanhToan = 1 and SanPham.CuaHangId = CuaHang.CuaHangId "
                        + "group by SanPham.CuaHangId, CuaHang.TenCuaHang, DonHang.ThoiGian", nativeQuery = true)
        List<Item> getImportantItems(); */