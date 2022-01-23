package r06.mall.Controllers;

import java.util.Collection;
import java.util.Objects;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RestController;

import r06.mall.JwtParser.JwtParser;
import r06.mall.Models.DonHang;
import r06.mall.Models.TinhTrangDonHang;
import r06.mall.Services.OrderService;

@SpringBootApplication
@CrossOrigin(origins = { "http://localhost:3000", "http://localhost:4200" })
@RestController
public class OrderController {
    private final OrderService _orderService;

    @Autowired
    public OrderController(OrderService orderService) {
        this._orderService = orderService;
    }

    @GetMapping("/tracking/{orderId}")
    public ResponseEntity<Collection<TinhTrangDonHang>> GetOrderTracking(@PathVariable String orderId,
            @RequestHeader(name = "Authorization") String token) {

        try {
            DonHang order = _orderService.GetDonHangById(orderId);
            if (Objects.isNull(order)) {
                return new ResponseEntity<>(HttpStatus.NOT_FOUND);
            }
            JwtParser jwt = new JwtParser(token);

            if (!jwt.isKhach() ||
                    !jwt.isAuthorized(order.getKhachHangId())) {
                return new ResponseEntity<>(HttpStatus.FORBIDDEN);
            }

            Collection<TinhTrangDonHang> orderStatus = _orderService.GetOrderTracking(order);
            return new ResponseEntity<>(orderStatus, HttpStatus.OK);

        } catch (IllegalArgumentException exception) {
            return new ResponseEntity<>(HttpStatus.FORBIDDEN);
        }
    }
    @GetMapping("/order_driver/{driverId}")
    public ResponseEntity<DonHang> getDonHangByDriver(String id, Integer tinhtrang,@RequestHeader(name = "Authorization") String token) {
        try {
            DonHang order = _orderService.getDonHangByDriverId(id,tinhtrang);
            JwtParser jwt = new JwtParser(token);

            // if (!jwt.isTaiXe()) {
            //     return new ResponseEntity<>(HttpStatus.FORBIDDEN);
            // }
            return new ResponseEntity<>(order, HttpStatus.OK);

        } catch (IllegalArgumentException exception) {
            return new ResponseEntity<>(HttpStatus.FORBIDDEN);
        }
    }

    @GetMapping("/order/unpicked")
    public ResponseEntity<Collection<DonHang>> getUnpickedOrder(String id, Integer tinhtrang,@RequestHeader(name = "Authorization") String token) {
        try {
            Collection<DonHang> listDh = _orderService.GetUnpickedOrder();
            return new ResponseEntity<>(listDh, HttpStatus.OK);
        }catch(IllegalArgumentException exception) {
            return new ResponseEntity<>(HttpStatus.FORBIDDEN);
        }
    }
}