package r06.mall.Services;

import java.util.List;

import org.springframework.stereotype.Service;

import r06.mall.Repositories.StoreRepository;
import r06.mall.Repositories.Report;

@Service
public class ReportService {
    private final StoreRepository cuahangRepository;

    public ReportService(StoreRepository cuaHangRepository) {
        this.cuahangRepository = cuaHangRepository;
    }


    public List<Report> findReportInQuarter(int nam, int quarter, String id) {
        var startMonth = 3* (quarter - 1) + 1;
        var endMonth = 3* quarter;
        return cuahangRepository.findReportByQuarter(startMonth, endMonth, nam, id);
    }
}
