package r06.mall.Services;

import java.util.List;

import org.springframework.stereotype.Service;

import r06.mall.Repositories.StoreRepository;
import r06.mall.Repositories.Commission;

@Service
public class CommissionService {
    private final StoreRepository cuaHangRepository;

    public CommissionService(StoreRepository cuaHangRepository) {
        this.cuaHangRepository = cuaHangRepository;
    }

    public List<Commission> findAllHoaHong() {
        return cuaHangRepository.findAllHoaHong();
    }

    public List<Commission> findHoaHongByNamAndThang(int nam, int thang) {
        return cuaHangRepository.findHoaHongByNamAndThang(nam, thang);
    }
}
