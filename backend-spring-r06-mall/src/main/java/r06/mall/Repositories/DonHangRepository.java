package r06.mall.Repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import r06.mall.Models.DonHang;

@Repository
public interface DonHangRepository extends JpaRepository<DonHang, String> {
}
