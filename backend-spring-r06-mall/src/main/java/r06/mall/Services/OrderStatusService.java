package r06.mall.Services;
import java.sql.Date;
import java.util.Optional;
import java.util.UUID;

import org.springframework.format.datetime.standard.DateTimeContext;
import org.springframework.stereotype.Service;

import r06.mall.Models.DonHang;
import r06.mall.Models.TinhTrangDonHang;
import r06.mall.Repositories.OrderRepository;
import r06.mall.Repositories.OrderStatusRepository;


@Service
public class OrderStatusService {
    private final OrderStatusRepository tinhTrangDonHangRepository;
    private final OrderRepository _donHangRepository;
    
    public OrderStatusService(OrderStatusRepository tinhTrangDonHangRepository,OrderRepository _donHangRepository) {
        this.tinhTrangDonHangRepository = tinhTrangDonHangRepository;
        this._donHangRepository = _donHangRepository;
    }

    public TinhTrangDonHang updateTinhTrang(TinhTrangDonHang entities) {
        entities.setTtdhId(UUID.randomUUID().toString());

        Optional<DonHang> donhang = _donHangRepository.findById(entities.getDonHangId());
        if (donhang.isPresent()) {
			DonHang _donhang = donhang.get();
			_donhang.setTinhTrangGiao(4);
            _donHangRepository.save(_donhang);
		}
        return tinhTrangDonHangRepository.save(entities);
    }
    public TinhTrangDonHang updateTinhTrangDonHang(String donHangId, String ttdh) {
        TinhTrangDonHang a = new TinhTrangDonHang();
        a.setTtdhId(UUID.randomUUID().toString());
        a.setDonHangId(donHangId);
        a.setNgayThucHien(new Date(System.currentTimeMillis()));
        a.setTenTinhTrang(ttdh);
        return tinhTrangDonHangRepository.save(a);

    }
}
