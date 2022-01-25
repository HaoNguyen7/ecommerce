package r06.mall.Repositories;
import java.util.Collection;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import r06.mall.Models.DonHang;

@Repository
public interface OrderRepository extends JpaRepository<DonHang, String> {
    @Query(value = "SELECT * FROM DonHang dh WHERE dh.NguoiGiaoHangNguoiGiaoId = ?1 and dh.TinhTrangGiao = ?2", nativeQuery = true)
    DonHang findDonHangByDriver(String id,Integer tinhtrang);
    @Query(value = "SELECT * from DonHang dh where dh.DonHangId in ("
        +"SELECT dh1.DonHangId FROM DonHang dh1, TinhTrangDonHang ttdh1 WHERE dh1.nguoiGiaoHangNguoiGiaoId is null and dh1.DonHangId = ttdh1.DonHangId "
        +"and ttdh1.TenTinhTrang = N'Đang đóng gói' and ttdh1.NgayThucHien >= "
        +"(SELECT top 1 ttdh2.NgayThucHien FROM DonHang dh2, TinhTrangDonHang ttdh2 WHERE dh2.nguoiGiaoHangNguoiGiaoId is null and dh2.DonHangId = ttdh2.DonHangId "
        +"and dh1.DonHangId = dh2.DonHangId order by ttdh2.NgayThucHien desc))", nativeQuery = true)
    Collection<DonHang> findAllUnpickedOrder();
    
    @Query(value = "select max(YEAR(ThoiGian)) Max, MIN(YEAR(ThoiGian)) Min from DonHang", nativeQuery = true)
    TimeRange findTimeRange();
    @Query(value = "SELECT dh.* from (DonHang dh join (SanPham sp join DonHangSanPham dhsp on sp.SanPhamId=dhsp.SanPhamId) on dh.DonHangId = dhsp.DonHangId) "
    +" join TinhTrangDonHang ttdh on dh.DonHangId = ttdh.DonHangId"
+" where sp.CuaHangId in (select CuaHangId"	
        +" from CuaHang" 
        +" where UserId = ?1) "
        +" and ttdh.DonHangId not in (select DonHangId from TinhTrangDonHang where TenTinhTrang = N'Đang đóng gói')", nativeQuery = true)
    Collection<DonHang> findAllWaitingOrder(String idUser);
    @Query(value = "Insert into TinhTrangDonHang (TTDHId, TenTinhTrang, DonHangId, NgayThucHien) values (NEWID(), N'Đang đóng gói', ?1, getDate())", nativeQuery = true)
    Integer updateTinhTrangDon(String id, String tinhtrang);
};

