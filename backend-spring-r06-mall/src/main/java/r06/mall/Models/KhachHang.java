package r06.mall.Models;

import javax.persistence.*;
import java.util.Collection;
import java.util.Objects;

@Entity
@Table(name = "KhachHang")
public class KhachHang {
    private String khachHangId;
    private String tenKhachHang;
    private String diaChi;
    private String cccd;
    private String stk;
    private String vung;
    private String email;
    private String soDienThoai;
    private Collection<DonHang> donHangsByKhachHangId;

    @Id
    @Column(name = "KhachHangId", nullable = false)
    public String getKhachHangId() {
        return khachHangId;
    }

    public void setKhachHangId(String khachHangId) {
        this.khachHangId = khachHangId;
    }

    @Basic
    @Column(name = "TenKhachHang", nullable = false, length = 50)
    public String getTenKhachHang() {
        return tenKhachHang;
    }

    public void setTenKhachHang(String tenKhachHang) {
        this.tenKhachHang = tenKhachHang;
    }

    @Basic
    @Column(name = "DiaChi", nullable = true, length = 50)
    public String getDiaChi() {
        return diaChi;
    }

    public void setDiaChi(String diaChi) {
        this.diaChi = diaChi;
    }

    @Basic
    @Column(name = "Cccd", nullable = true, length = 12)
    public String getCccd() {
        return cccd;
    }

    public void setCccd(String cccd) {
        this.cccd = cccd;
    }

    @Basic
    @Column(name = "STK", nullable = true, length = 30)
    public String getStk() {
        return stk;
    }

    public void setStk(String stk) {
        this.stk = stk;
    }

    @Basic
    @Column(name = "Vung", nullable = true, length = 30)
    public String getVung() {
        return vung;
    }

    public void setVung(String vung) {
        this.vung = vung;
    }

    @Basic
    @Column(name = "Email", nullable = true, length = 2147483647)
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Basic
    @Column(name = "SoDienThoai", nullable = true, length = 10)
    public String getSoDienThoai() {
        return soDienThoai;
    }

    public void setSoDienThoai(String soDienThoai) {
        this.soDienThoai = soDienThoai;
    }

    @Override
    public boolean equals(Object o) {

        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        KhachHang khachHang = (KhachHang) o;
        return Objects.equals(khachHangId, khachHang.khachHangId) && Objects.equals(tenKhachHang, khachHang.tenKhachHang) && Objects.equals(diaChi, khachHang.diaChi) && Objects.equals(cccd, khachHang.cccd) && Objects.equals(stk, khachHang.stk) && Objects.equals(vung, khachHang.vung) && Objects.equals(email, khachHang.email) && Objects.equals(soDienThoai, khachHang.soDienThoai);
    }

    @Override
    public int hashCode() {
        return Objects.hash(khachHangId, tenKhachHang, diaChi, cccd, stk, vung, email, soDienThoai);
    }

    @OneToMany(mappedBy = "khachHangByKhachHangId")
    public Collection<DonHang> getDonHangsByKhachHangId() {
        return donHangsByKhachHangId;
    }

    public void setDonHangsByKhachHangId(Collection<DonHang> donHangsByKhachHangId) {
        this.donHangsByKhachHangId = donHangsByKhachHangId;
    }
}
