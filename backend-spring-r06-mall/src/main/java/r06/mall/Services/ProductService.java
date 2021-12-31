package r06.mall.Services;

import org.springframework.stereotype.Service;

import r06.mall.Models.SanPham;
import r06.mall.Repositories.ProductRepository;

import java.util.List;

@Service
public class ProductService {
    private final ProductRepository sanPhamRepository;

    public ProductService(ProductRepository sanPhamRepository) {
        this.sanPhamRepository = sanPhamRepository;
    }

    public List<SanPham> getSanPham() {
        return sanPhamRepository.findAll();

    }
}
