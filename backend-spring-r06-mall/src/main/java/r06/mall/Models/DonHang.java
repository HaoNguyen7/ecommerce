package r06.mall.Models;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

import java.sql.Date;
import java.util.Collection;
import java.util.Objects;

@Entity
@Table(name="DonHang")
public class DonHang {
    private String donHangId;
    private Date thoiGian;
    private Boolean tinhTrangThanhToan;
    private String danhGia;
    private Integer soLuong;
    private String hinhThucThanhToanHinhThucId;
    private String khachHangId;
    private String nguoiGiaoHangNguoiGiaoId;
    private Integer tinhTrangGiao;
    private HinhThucThanhToan hinhThucThanhToanByHinhThucThanhToanHinhThucId;
    private KhachHang khachHangByKhachHangId;
    private NguoiGiaoHang nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId;
    private Collection<DonHangSanPham> donHangSanPhamsByDonHangId;
    private Collection<TinhTrangDonHang> tinhTrangDonHangsByDonHangId;
    private Integer TongTien;
    private String DiaChi;
    private String ThanhPho;
    @Id
    @Column(name = "DonHangId", nullable = false)
    public String getDonHangId() {
        return donHangId;
    }

    public void setDonHangId(String donHangId) {
        this.donHangId = donHangId;
    }

    @Basic
    @Column(name = "ThoiGian", nullable = false)
    public Date getThoiGian() {
        return thoiGian;
    }

    public void setThoiGian(Date thoiGian) {
        this.thoiGian = thoiGian;
    }

    @Basic
    @Column(name = "TinhTrangThanhToan", nullable = false)
    public Boolean getTinhTrangThanhToan() {
        return tinhTrangThanhToan;
    }

    public void setTinhTrangThanhToan(Boolean tinhTrangThanhToan) {
        this.tinhTrangThanhToan = tinhTrangThanhToan;
    }

    @Basic
    @Column(name = "DanhGia", nullable = true, length = 2147483647)
    public String getDanhGia() {
        return danhGia;
    }

    public void setDanhGia(String danhGia) {
        this.danhGia = danhGia;
    }

    @Basic
    @Column(name = "SoLuong", nullable = false)
    public Integer getSoLuong() {
        return soLuong;
    }

    public void setSoLuong(Integer soLuong) {
        this.soLuong = soLuong;
    }

    @Basic
    @Column(name = "TinhTrangGiao", nullable = false)
    public Integer getTinhTrangGiao() {
        return tinhTrangGiao;
    }

    public void setTinhTrangGiao(Integer tinhTrangGiao) {
        this.tinhTrangGiao = tinhTrangGiao;
    }

    @Basic
    @Column(name = "HinhThucThanhToanHinhThucId", nullable = true)
    public String getHinhThucThanhToanHinhThucId() {
        return hinhThucThanhToanHinhThucId;
    }

    public void setHinhThucThanhToanHinhThucId(String hinhThucThanhToanHinhThucId) {
        this.hinhThucThanhToanHinhThucId = hinhThucThanhToanHinhThucId;
    }

    @Basic
    @Column(name = "KhachHangId", nullable = true)
    public String getKhachHangId() {
        return khachHangId;
    }

    public void setKhachHangId(String khachHangId) {
        this.khachHangId = khachHangId;
    }

    @Basic
    @Column(name = "NguoiGiaoHangNguoiGiaoId", nullable = true)
    public String getNguoiGiaoHangNguoiGiaoId() {
        return nguoiGiaoHangNguoiGiaoId;
    }

    public void setNguoiGiaoHangNguoiGiaoId(String nguoiGiaoHangNguoiGiaoId) {
        this.nguoiGiaoHangNguoiGiaoId = nguoiGiaoHangNguoiGiaoId;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        DonHang donHang = (DonHang) o;
        return Objects.equals(donHangId, donHang.donHangId) && Objects.equals(thoiGian, donHang.thoiGian) && Objects.equals(tinhTrangThanhToan, donHang.tinhTrangThanhToan) && Objects.equals(danhGia, donHang.danhGia) && Objects.equals(soLuong, donHang.soLuong) && Objects.equals(hinhThucThanhToanHinhThucId, donHang.hinhThucThanhToanHinhThucId) && Objects.equals(khachHangId, donHang.khachHangId) && Objects.equals(nguoiGiaoHangNguoiGiaoId, donHang.nguoiGiaoHangNguoiGiaoId);
    }

    @Override
    public int hashCode() {
        return Objects.hash(donHangId, thoiGian, tinhTrangThanhToan, danhGia, soLuong, hinhThucThanhToanHinhThucId, khachHangId, nguoiGiaoHangNguoiGiaoId);
    }

    @ManyToOne
    @JsonIgnore
    @JoinColumn(name = "HinhThucThanhToanHinhThucId", referencedColumnName = "HinhThucId", insertable = false, updatable = false)
    public HinhThucThanhToan getHinhThucThanhToanByHinhThucThanhToanHinhThucId() {
        return hinhThucThanhToanByHinhThucThanhToanHinhThucId;
    }

    public void setHinhThucThanhToanByHinhThucThanhToanHinhThucId(HinhThucThanhToan hinhThucThanhToanByHinhThucThanhToanHinhThucId) {
        this.hinhThucThanhToanByHinhThucThanhToanHinhThucId = hinhThucThanhToanByHinhThucThanhToanHinhThucId;
    }

    @ManyToOne
    @JsonIgnore
    @JoinColumn(name = "KhachHangId", referencedColumnName = "KhachHangId", insertable = false, updatable = false)
    public KhachHang getKhachHangByKhachHangId() {
        return khachHangByKhachHangId;
    }

    public void setKhachHangByKhachHangId(KhachHang khachHangByKhachHangId) {
        this.khachHangByKhachHangId = khachHangByKhachHangId;
    }

    @ManyToOne
    @JsonIgnore
    @JoinColumn(name = "NguoiGiaoHangNguoiGiaoId", referencedColumnName = "NguoiGiaoId", insertable = false, updatable = false)
    public NguoiGiaoHang getNguoiGiaoHangByNguoiGiaoHangNguoiGiaoId() {
        return nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId;
    }

    public void setNguoiGiaoHangByNguoiGiaoHangNguoiGiaoId(NguoiGiaoHang nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId) {
        this.nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId = nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId;
    }

    @OneToMany(mappedBy = "donHangByDonHangId")
    public Collection<DonHangSanPham> getDonHangSanPhamsByDonHangId() {
        return donHangSanPhamsByDonHangId;
    }

    public void setDonHangSanPhamsByDonHangId(Collection<DonHangSanPham> donHangSanPhamsByDonHangId) {
        this.donHangSanPhamsByDonHangId = donHangSanPhamsByDonHangId;
    }

    @OneToMany(mappedBy = "donHangByDonHangId")
    public Collection<TinhTrangDonHang> getTinhTrangDonHangsByDonHangId() {
        return tinhTrangDonHangsByDonHangId;
    }

    public void setTinhTrangDonHangsByDonHangId(Collection<TinhTrangDonHang> tinhTrangDonHangsByDonHangId) {
        this.tinhTrangDonHangsByDonHangId = tinhTrangDonHangsByDonHangId;
    }

    @Basic
    @Column(name = "DiaChi", nullable = false, length = 2147483647)
    public String getDiaChi() {
        return DiaChi;
    }

    public void setDiaChi(String DiaChi) {
        this.DiaChi = DiaChi;
    }

    @Basic
    @Column(name = "ThanhPho", nullable = false, length = 2147483647)
    public String getThanhPho() {
        return ThanhPho;
    }

    public void setThanhPho(String ThanhPho) {
        this.ThanhPho = ThanhPho;
    }

    @Basic
    @Column(name = "TongTien", nullable = false)
    public Integer getTongTien() {
        return TongTien;
    }

    public void setTongTien(Integer TongTien) {
        this.TongTien = TongTien;
    }

}
