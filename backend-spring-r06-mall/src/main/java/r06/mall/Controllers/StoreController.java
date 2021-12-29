package r06.mall.Controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import r06.mall.JwtParser.JwtParser;
import r06.mall.Repositories.Commission;
import r06.mall.Responses.HoaHongResponse;
import r06.mall.Services.CommissionService;

@RestController
public class StoreController {
    private final CommissionService hoaHongService;

    @Autowired
    public StoreController(CommissionService hoaHongService) {
        this.hoaHongService = hoaHongService;
    }

    @GetMapping("/commission")
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

}
