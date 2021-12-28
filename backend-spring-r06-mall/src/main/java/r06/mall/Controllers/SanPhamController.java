package r06.mall.Controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import r06.mall.Models.SanPham;
import r06.mall.Services.SanPhamService;

import java.util.List;

@RestController
public class SanPhamController {
    private final SanPhamService sanPhamService;

    @Autowired
    public SanPhamController(SanPhamService sanPhamService) {
        this.sanPhamService = sanPhamService;
    }

    @GetMapping
    public List<SanPham> getSanPham() {
        return sanPhamService.getSanPham();
    }

}
