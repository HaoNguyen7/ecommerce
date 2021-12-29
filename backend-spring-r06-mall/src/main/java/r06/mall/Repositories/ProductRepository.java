package r06.mall.Repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import r06.mall.Models.SanPham;

@Repository
public interface ProductRepository extends JpaRepository<SanPham, String> {

}
