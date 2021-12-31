package r06.mall.Models;

import javax.persistence.*;
import java.sql.Date;
import java.util.Collection;
import java.util.Objects;

@Entity
@Table(name = "NguoiGiaoHang")
public class NguoiGiaoHang {
    private String nguoiGiaoId;
    private String tenNguoiGiaoHang;
    private String soDienThoai;
    private String diaChi;
    private String cccd;
    private String stk;
    private String vungHoatDong;
    private String email;
    private Date ngayDangKy;
    private Collection<DonHang> donHangsByNguoiGiaoId;
    private Collection<KetQuaKiemTra> ketQuaKiemTrasByNguoiGiaoId;
    private Collection<ThongTinDiDuong> thongTinDiDuongsByNguoiGiaoId;

    @Id
    @Column(name = "NguoiGiaoId", nullable = false)
    public String getNguoiGiaoId() {
        return nguoiGiaoId;
    }

    public void setNguoiGiaoId(String nguoiGiaoId) {
        this.nguoiGiaoId = nguoiGiaoId;
    }

    @Basic
    @Column(name = "TenNguoiGiaoHang", nullable = true, length = 50)
    public String getTenNguoiGiaoHang() {
        return tenNguoiGiaoHang;
    }

    public void setTenNguoiGiaoHang(String tenNguoiGiaoHang) {
        this.tenNguoiGiaoHang = tenNguoiGiaoHang;
    }

    @Basic
    @Column(name = "SoDienThoai", nullable = true, length = 10)
    public String getSoDienThoai() {
        return soDienThoai;
    }

    public void setSoDienThoai(String soDienThoai) {
        this.soDienThoai = soDienThoai;
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
    @Column(name = "VungHoatDong", nullable = true, length = 30)
    public String getVungHoatDong() {
        return vungHoatDong;
    }

    public void setVungHoatDong(String vungHoatDong) {
        this.vungHoatDong = vungHoatDong;
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
    @Column(name = "NgayDangKy", nullable = false)
    public Date getNgayDangKy() {
        return ngayDangKy;
    }

    public void setNgayDangKy(Date ngayDangKy) {
        this.ngayDangKy = ngayDangKy;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        NguoiGiaoHang that = (NguoiGiaoHang) o;
        return Objects.equals(nguoiGiaoId, that.nguoiGiaoId) && Objects.equals(tenNguoiGiaoHang, that.tenNguoiGiaoHang) && Objects.equals(soDienThoai, that.soDienThoai) && Objects.equals(diaChi, that.diaChi) && Objects.equals(cccd, that.cccd) && Objects.equals(stk, that.stk) && Objects.equals(vungHoatDong, that.vungHoatDong) && Objects.equals(email, that.email) && Objects.equals(ngayDangKy, that.ngayDangKy);
    }

    @Override
    public int hashCode() {
        return Objects.hash(nguoiGiaoId, tenNguoiGiaoHang, soDienThoai, diaChi, cccd, stk, vungHoatDong, email, ngayDangKy);
    }

    @OneToMany(mappedBy = "nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId")
    public Collection<DonHang> getDonHangsByNguoiGiaoId() {
        return donHangsByNguoiGiaoId;
    }

    public void setDonHangsByNguoiGiaoId(Collection<DonHang> donHangsByNguoiGiaoId) {
        this.donHangsByNguoiGiaoId = donHangsByNguoiGiaoId;
    }

    @OneToMany(mappedBy = "nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId")
    public Collection<KetQuaKiemTra> getKetQuaKiemTrasByNguoiGiaoId() {
        return ketQuaKiemTrasByNguoiGiaoId;
    }

    public void setKetQuaKiemTrasByNguoiGiaoId(Collection<KetQuaKiemTra> ketQuaKiemTrasByNguoiGiaoId) {
        this.ketQuaKiemTrasByNguoiGiaoId = ketQuaKiemTrasByNguoiGiaoId;
    }

    @OneToMany(mappedBy = "nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId")
    public Collection<ThongTinDiDuong> getThongTinDiDuongsByNguoiGiaoId() {
        return thongTinDiDuongsByNguoiGiaoId;
    }

    public void setThongTinDiDuongsByNguoiGiaoId(Collection<ThongTinDiDuong> thongTinDiDuongsByNguoiGiaoId) {
        this.thongTinDiDuongsByNguoiGiaoId = thongTinDiDuongsByNguoiGiaoId;
    }
}
