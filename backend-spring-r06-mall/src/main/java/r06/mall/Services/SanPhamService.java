package r06.mall.Services;

import org.springframework.stereotype.Component;
import org.springframework.stereotype.Controller;
import r06.mall.Models.SanPham;
import r06.mall.Repositories.SanPhamRepository;

import java.util.List;

@Component
public class SanPhamService {
    private final SanPhamRepository sanPhamRepository;

    public SanPhamService(SanPhamRepository sanPhamRepository) {
        this.sanPhamRepository = sanPhamRepository;
    }

    public List<SanPham> getSanPham() {
        return sanPhamRepository.findAll();
    }
}
