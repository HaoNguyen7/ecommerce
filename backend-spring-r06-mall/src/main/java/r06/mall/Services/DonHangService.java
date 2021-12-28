package r06.mall.Services;

import org.springframework.stereotype.Service;
import r06.mall.Models.DonHang;
import r06.mall.Repositories.DonHangRepository;

import java.util.List;

@Service
public class DonHangService {
    private final DonHangRepository donHangRepository;
    public DonHangService(DonHangRepository donHangRepository) {
        this.donHangRepository = donHangRepository;
    }
    public List<DonHang> geProducts() {
        return donHangRepository.findAll();
    }
}
