package r06.mall.Models;

import javax.persistence.*;
import java.util.Collection;
import java.util.Objects;

@Entity
@Table(name="HinhThucThanhToan")
public class HinhThucThanhToan {
    private String hinhThucId;
    private String tenHttt;
    private Collection<DonHang> donHangsByHinhThucId;

    @Id
    @Column(name = "HinhThucId", nullable = false)
    public String getHinhThucId() {
        return hinhThucId;
    }

    public void setHinhThucId(String hinhThucId) {
        this.hinhThucId = hinhThucId;
    }

    @Basic
    @Column(name = "TenHTTT", nullable = true, length = 50)
    public String getTenHttt() {
        return tenHttt;
    }

    public void setTenHttt(String tenHttt) {
        this.tenHttt = tenHttt;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        HinhThucThanhToan that = (HinhThucThanhToan) o;
        return Objects.equals(hinhThucId, that.hinhThucId) && Objects.equals(tenHttt, that.tenHttt);
    }

    @Override
    public int hashCode() {
        return Objects.hash(hinhThucId, tenHttt);
    }

    @OneToMany(mappedBy = "hinhThucThanhToanByHinhThucThanhToanHinhThucId")
    public Collection<DonHang> getDonHangsByHinhThucId() {
        return donHangsByHinhThucId;
    }

    public void setDonHangsByHinhThucId(Collection<DonHang> donHangsByHinhThucId) {
        this.donHangsByHinhThucId = donHangsByHinhThucId;
    }
}
