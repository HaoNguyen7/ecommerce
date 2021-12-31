package r06.mall.Models;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

import java.sql.Date;
import java.util.Objects;

@Entity
@Table(name="TinhTrangDonHang")
public class TinhTrangDonHang {
    private String ttdhId;
    private String tenTinhTrang;
    private String donHangId;
    private String ghiChu;
    private Date ngayThucHien;
    private DonHang donHangByDonHangId;

    @Id
    @Column(name = "TTDHId", nullable = false)
    public String getTtdhId() {
        return ttdhId;
    }

    public void setTtdhId(String ttdhId) {
        this.ttdhId = ttdhId;
    }

    @Basic
    @Column(name = "TenTinhTrang", nullable = true, length = 30)
    public String getTenTinhTrang() {
        return tenTinhTrang;
    }

    public void setTenTinhTrang(String tenTinhTrang) {
        this.tenTinhTrang = tenTinhTrang;
    }

    @Basic
    @Column(name = "DonHangId", nullable = true)
    public String getDonHangId() {
        return donHangId;
    }

    public void setDonHangId(String donHangId) {
        this.donHangId = donHangId;
    }

    @Basic
    @Column(name = "GhiChu", nullable = true, length = 2147483647)
    public String getGhiChu() {
        return ghiChu;
    }

    public void setGhiChu(String ghiChu) {
        this.ghiChu = ghiChu;
    }

    @Basic
    @Column(name = "NgayThucHien", nullable = false)
    public Date getNgayThucHien() {
        return ngayThucHien;
    }

    public void setNgayThucHien(Date ngayThucHien) {
        this.ngayThucHien = ngayThucHien;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        TinhTrangDonHang that = (TinhTrangDonHang) o;
        return Objects.equals(ttdhId, that.ttdhId) && Objects.equals(tenTinhTrang, that.tenTinhTrang) && Objects.equals(donHangId, that.donHangId) && Objects.equals(ghiChu, that.ghiChu) && Objects.equals(ngayThucHien, that.ngayThucHien);
    }

    @Override
    public int hashCode() {
        return Objects.hash(ttdhId, tenTinhTrang, donHangId, ghiChu, ngayThucHien);
    }

    @ManyToOne
    @JsonIgnore
    @JoinColumn(name = "DonHangId", referencedColumnName = "DonHangId", insertable = false, updatable = false)
    public DonHang getDonHangByDonHangId() {
        return donHangByDonHangId;
    }

    public void setDonHangByDonHangId(DonHang donHangByDonHangId) {
        this.donHangByDonHangId = donHangByDonHangId;
    }
}
