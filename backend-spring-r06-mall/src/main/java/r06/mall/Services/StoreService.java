package r06.mall.Services;

import java.util.Optional;

import org.springframework.stereotype.Service;

import r06.mall.Models.CuaHang;
import r06.mall.Repositories.StoreRepository;

@Service
public class StoreService {
    private final StoreRepository storeRepository;

    public StoreService(StoreRepository storeRepository) {
        this.storeRepository = storeRepository;
    }

    public Optional<CuaHang> findStoreById(String storeId) {
        return storeRepository.findById(storeId);
    }
}
