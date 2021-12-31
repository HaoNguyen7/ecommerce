package r06.mall.Controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import r06.mall.Models.TinhTrangDonHang;
import r06.mall.Services.OrderStatusService;

@SpringBootApplication
@CrossOrigin(origins = { "http://localhost:3000", "http://localhost:4200" })
@RestController
public class OrderStatusController {
    private final OrderStatusService tinhTrangDonHangService;

    @Autowired
    public OrderStatusController(OrderStatusService tinhTrangDonHangService) {
        this.tinhTrangDonHangService = tinhTrangDonHangService;
    }

    @PostMapping("/tinhtrang")
    public TinhTrangDonHang getSanPham(@RequestBody TinhTrangDonHang tinhTrangDonHang) {
        return tinhTrangDonHangService.updateTinhTrang(tinhTrangDonHang);
    }
}
