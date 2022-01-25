package r06.mall.Controllers;

import java.util.Collection;
import java.util.List;
import java.util.Optional;

import javax.websocket.server.PathParam;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import r06.mall.JwtParser.JwtParser;
import r06.mall.Models.CuaHang;
import r06.mall.Models.SanPham;
import r06.mall.Repositories.Commission;
import r06.mall.Repositories.Report;
import r06.mall.Responses.HoaHongResponse;
import r06.mall.Responses.ReportResponse;
import r06.mall.Responses.StoreDetailResponse;
import r06.mall.Services.CommissionService;
import r06.mall.Services.ReportService;
import r06.mall.Services.StoreService;

@RestController
@CrossOrigin(origins = { "http://localhost:3000", "http://localhost:4200" })
@SpringBootApplication
public class StoreController {
    private final CommissionService hoaHongService;
    private final StoreService storeService;
    private final ReportService reportService;

    @Autowired
    public StoreController(CommissionService hoaHongService, StoreService storeService, ReportService reportService) {
        this.hoaHongService = hoaHongService;
        this.storeService = storeService;
        this.reportService = reportService;
    }

    @GetMapping("/store/commission")
    public ResponseEntity<HoaHongResponse> findHoaHong(@RequestHeader(name = "Authorization") String token) {
        try {
            JwtParser jwt = new JwtParser(token);
            // if (!jwt.isAdmin()) {
            // return new ResponseEntity<HoaHongResponse>(new HoaHongResponse(
            // false), HttpStatus.FORBIDDEN);
            // }
            List<Commission> list = hoaHongService.findAllHoaHong();
            return new ResponseEntity<HoaHongResponse>(new HoaHongResponse(
                    true, "", list), HttpStatus.OK);
        } catch (IllegalAccessError err) {
            return new ResponseEntity<HoaHongResponse>(new HoaHongResponse(
                    false), HttpStatus.UNAUTHORIZED);
        }
    }

    @RequestMapping(value = "/store/report", method = RequestMethod.GET)
    public ResponseEntity<ReportResponse> findReportByQuarter(
            @RequestParam(value = "year", required = false, defaultValue = "2022") String year,
            @RequestParam(value = "quarter", required = false, defaultValue = "2") String quarter,
            @RequestParam(value = "idCuaHang", required = false, defaultValue = "0482BF2A-DEDC-4980-CF0C-08D9D8CF552A") String idCuaHang) {
        List<Report> list = reportService.findReportInQuarter(Integer.parseInt(year), Integer.parseInt(quarter),
                idCuaHang);
        return new ResponseEntity<ReportResponse>(new ReportResponse(
                true, "Success", list), HttpStatus.OK);
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
