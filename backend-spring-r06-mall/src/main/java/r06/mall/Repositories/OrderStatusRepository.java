package r06.mall.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import r06.mall.Models.TinhTrangDonHang;

@Repository
public interface OrderStatusRepository extends JpaRepository<TinhTrangDonHang, String> {
    @Query(value = "Select *  from TinhTrangDonHang where DonHangId = ?1 order by NgayThucHien Desc", nativeQuery = true)
    public List<TinhTrangDonHang> findOrderTracking(String orderId);
}