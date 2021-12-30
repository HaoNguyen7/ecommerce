package r06.mall.Controllers;

import java.util.Collection;
import java.util.List;
import java.util.Optional;

import javax.websocket.server.PathParam;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import r06.mall.JwtParser.JwtParser;
import r06.mall.Models.CuaHang;
import r06.mall.Models.SanPham;
import r06.mall.Repositories.Commission;
import r06.mall.Responses.HoaHongResponse;
import r06.mall.Responses.StoreDetailResponse;
import r06.mall.Services.CommissionService;
import r06.mall.Services.StoreService;

@RestController
public class StoreController {
    private final CommissionService hoaHongService;
    private final StoreService storeService;

    @Autowired
    public StoreController(CommissionService hoaHongService, StoreService storeService) {
        this.hoaHongService = hoaHongService;
        this.storeService = storeService;
    }

    @GetMapping("/store/commission")
    public ResponseEntity<HoaHongResponse> findHoaHongByNamAndThang(@RequestParam int year, @RequestParam int month,
            @RequestHeader(name = "Authorization") String token) {
        try {
            JwtParser jwt = new JwtParser(token);
            if (!jwt.isAdmin()) {
                return new ResponseEntity<HoaHongResponse>(new HoaHongResponse(
                        false), HttpStatus.FORBIDDEN);
            }
            List<Commission> list = hoaHongService.findHoaHongByNamAndThang(year, month);
            return new ResponseEntity<HoaHongResponse>(new HoaHongResponse(
                    true, "", list), HttpStatus.OK);
        } catch (IllegalAccessError err) {
            return new ResponseEntity<HoaHongResponse>(new HoaHongResponse(
                    false), HttpStatus.UNAUTHORIZED);
        }
    }

    @GetMapping("/store/{storeId}")
    public ResponseEntity<StoreDetailResponse> getStoreById(@PathVariable String storeId) {
        Optional<CuaHang> storeFind = storeService.findStoreById(storeId);
        if (storeFind.isPresent()) {
            return new ResponseEntity<StoreDetailResponse>(new StoreDetailResponse(
                    storeFind.get(),
                    storeFind.get().getSanPhamsByCuaHangId()), HttpStatus.OK);
        }
        return new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

}
