package r06.mall.Services;

import org.springframework.stereotype.Service;
import r06.mall.Models.DonHang;
import r06.mall.Models.TinhTrangDonHang;
import r06.mall.Repositories.OrderRepository;
import r06.mall.Repositories.OrderStatusRepository;
import r06.mall.Repositories.TimeRange;

import java.util.Collection;
import java.util.List;
import java.util.Optional;

@Service
public class OrderService {
    private final OrderRepository _donHangRepository;
    private final OrderStatusRepository _orderStatusRepository;

    public OrderService(OrderRepository donHangRepository, OrderStatusRepository orderStatusRepository) {
        this._donHangRepository = donHangRepository;
        this._orderStatusRepository = orderStatusRepository;
    }

    public DonHang GetDonHangById(String orderId) {

        Optional<DonHang> orderOpt = _donHangRepository.findById(orderId);
        if (!orderOpt.isPresent()) {
            return null;
        } else {
            return orderOpt.get();
        }

    }

    public TimeRange findTimeRange() {
        return _donHangRepository.findTimeRange();
    }
    public Collection<TinhTrangDonHang> GetOrderTracking(DonHang order) {
        return _orderStatusRepository.findOrderTracking(order.getDonHangId());
    }

    public DonHang getDonHangByDriverId(String id, Integer tinhtrang) {
        return _donHangRepository.findDonHangByDriver(id, tinhtrang);
    }

    public Collection<DonHang> GetUnpickedOrder(){
        return _donHangRepository.findAllUnpickedOrder();
    }

    public Collection<DonHang> GetWaitingOrder(String idUser){
        return _donHangRepository.findAllWaitingOrder(idUser);
    }

    // public Integer updateTinhTrangDon(String id){
    //     return _donHangRepository.updateTinhTrangDon(id)
    // }
}
