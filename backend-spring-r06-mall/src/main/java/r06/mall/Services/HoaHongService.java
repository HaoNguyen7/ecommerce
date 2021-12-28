package r06.mall.Services;

import java.util.List;

import org.springframework.stereotype.Service;

import r06.mall.Repositories.CuaHangRepository;
import r06.mall.Repositories.HoaHong;

@Service
public class HoaHongService {
    private final CuaHangRepository cuaHangRepository;

    public HoaHongService(CuaHangRepository cuaHangRepository) {
        this.cuaHangRepository = cuaHangRepository;
    }

    public List<HoaHong> findAllHoaHong() {
        return cuaHangRepository.findAllHoaHong();
    }

    public List<HoaHong> findHoaHongByNamAndThang(int nam, int thang) {
        return cuaHangRepository.findHoaHongByNamAndThang(nam, thang);
    }
}
