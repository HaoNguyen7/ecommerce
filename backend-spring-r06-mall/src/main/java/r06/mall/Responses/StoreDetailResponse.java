package r06.mall.Responses;

import java.util.Collection;

import r06.mall.Models.CuaHang;
import r06.mall.Models.SanPham;

public class StoreDetailResponse {
    public CuaHang store;
    public Collection<SanPham> products;

    public StoreDetailResponse(CuaHang store, Collection<SanPham> products) {
        this.store = store;
        this.products = products;
    }

}
