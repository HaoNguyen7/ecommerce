package r06.mall.Controllers;

import java.time.LocalDate;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;

import r06.mall.Repositories.HoaHong;
import r06.mall.Services.HoaHongService;

@RestController
public class HoaHongController {
    private final HoaHongService hoaHongService;

    @Autowired
    public HoaHongController(HoaHongService hoaHongService) {
        this.hoaHongService = hoaHongService;
    }

    @GetMapping("/hoahong")
    public ResponseEntity<List<HoaHong>> findHoaHongByNamAndThang(
            @RequestParam int year,
            @RequestParam int month) {
        List<HoaHong> list = hoaHongService.findHoaHongByNamAndThang(year, month);
        return new ResponseEntity<List<HoaHong>>(list, HttpStatus.OK);
    }

}
