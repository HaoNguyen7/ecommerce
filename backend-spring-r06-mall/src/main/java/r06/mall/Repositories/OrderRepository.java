package r06.mall.Repositories;
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
}
