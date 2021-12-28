package r06.mall.Models;

import javax.persistence.Column;
import javax.persistence.Id;
import java.io.Serializable;
import java.util.Objects;

public class DonHangSanPhamPK implements Serializable {
    private String donHangId;
    private String sanPhamId;

    @Column(name = "DonHangId", nullable = false)
    @Id
    public String getDonHangId() {
        return donHangId;
    }

    public void setDonHangId(String donHangId) {
        this.donHangId = donHangId;
    }

    @Column(name = "SanPhamId", nullable = false)
    @Id
    public String getSanPhamId() {
        return sanPhamId;
    }

    public void setSanPhamId(String sanPhamId) {
        this.sanPhamId = sanPhamId;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        DonHangSanPhamPK that = (DonHangSanPhamPK) o;
        return Objects.equals(donHangId, that.donHangId) && Objects.equals(sanPhamId, that.sanPhamId);
    }

    @Override
    public int hashCode() {
        return Objects.hash(donHangId, sanPhamId);
    }
}
