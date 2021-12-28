package r06.mall.Models;

import com.fasterxml.jackson.annotation.JsonManagedReference;

import javax.persistence.*;
import java.util.Objects;

@Entity
@Table(name="DonHangSanPham")
@IdClass(DonHangSanPhamPK.class)
public class DonHangSanPham {
    private String donHangId;
    private String sanPhamId;
    private Integer soLuong;
    private DonHang donHangByDonHangId;
    private SanPham sanPhamBySanPhamId;

    @Id
    @Column(name = "DonHangId", nullable = false)
    public String getDonHangId() {
        return donHangId;
    }

    public void setDonHangId(String donHangId) {
        this.donHangId = donHangId;
    }

    @Id
    @Column(name = "SanPhamId", nullable = false)
    public String getSanPhamId() {
        return sanPhamId;
    }

    public void setSanPhamId(String sanPhamId) {
        this.sanPhamId = sanPhamId;
    }

    @Basic
    @Column(name = "SoLuong", nullable = false)
    public Integer getSoLuong() {
        return soLuong;
    }

    public void setSoLuong(Integer soLuong) {
        this.soLuong = soLuong;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        DonHangSanPham that = (DonHangSanPham) o;
        return Objects.equals(donHangId, that.donHangId) && Objects.equals(sanPhamId, that.sanPhamId) && Objects.equals(soLuong, that.soLuong);
    }

    @Override
    public int hashCode() {
        return Objects.hash(donHangId, sanPhamId, soLuong);
    }

    @JsonManagedReference
    @ManyToOne(optional=false)
    @JoinColumn(name = "DonHangId", referencedColumnName = "DonHangId", nullable = false, insertable = false, updatable = false)
    public DonHang getDonHangByDonHangId() {
        return donHangByDonHangId;
    }

    public void setDonHangByDonHangId(DonHang donHangByDonHangId) {
        this.donHangByDonHangId = donHangByDonHangId;
    }

    @JsonManagedReference
    @ManyToOne(optional=false)
    @JoinColumn(name = "SanPhamId", referencedColumnName = "SanPhamId", nullable = false, insertable = false, updatable = false)
    public SanPham getSanPhamBySanPhamId() {
        return sanPhamBySanPhamId;
    }

    public void setSanPhamBySanPhamId(SanPham sanPhamBySanPhamId) {
        this.sanPhamBySanPhamId = sanPhamBySanPhamId;
    }
}
