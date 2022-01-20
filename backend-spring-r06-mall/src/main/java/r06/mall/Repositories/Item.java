package r06.mall.Repositories;

import r06.mall.Models.SanPham;

public interface Item {
    String sanPhamId();
    SanPham getSanPhamBySanPhamId();
    int getSoLuong();
}
