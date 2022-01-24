package r06.mall.Models;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonManagedReference;

import javax.persistence.*;
import java.sql.Date;
import java.util.Collection;
import java.util.Objects;

@Entity(name="SanPham")
@Table(name="SanPham")
public class SanPham {
    private String sanPhamId;
    private String tenSanPham;
    private String moTa;
    private Integer tonKho;
    private Integer donGia;
    private String donVi;
    private String loaiSanPhamLoaiId;
    private String cuaHangId;
    private Date ngayDang;
    private Collection<DonHangSanPham> donHangSanPhamsBySanPhamId;
    private LoaiSanPham loaiSanPhamByLoaiSanPhamLoaiId;
    private CuaHang cuaHangByCuaHangId;

    @Id
    @Column(name = "SanPhamId", nullable = false)
    public String getSanPhamId() {
        return sanPhamId;
    }

    public void setSanPhamId(String sanPhamId) {
        this.sanPhamId = sanPhamId;
    }

    @Basic
    @Column(name = "TenSanPham", nullable = false, length = 50)
    public String getTenSanPham() {
        return tenSanPham;
    }

    public void setTenSanPham(String tenSanPham) {
        this.tenSanPham = tenSanPham;
    }

    @Basic
    @Column(name = "MoTa", nullable = true, length = 2147483647)
    public String getMoTa() {
        return moTa;
    }

    public void setMoTa(String moTa) {
        this.moTa = moTa;
    }

    @Basic
    @Column(name = "TonKho", nullable = false)
    public Integer getTonKho() {
        return tonKho;
    }

    public void setTonKho(Integer tonKho) {
        this.tonKho = tonKho;
    }

    @Basic
    @Column(name = "DonGia", nullable = false)
    public Integer getDonGia() {
        return donGia;
    }

    public void setDonGia(Integer donGia) {
        this.donGia = donGia;
    }

    @Basic
    @Column(name = "DonVi", nullable = false)
    public String getDonVi() {
        return donVi;
    }

    public void setDonVi(String donVi) {
        this.donVi = donVi;
    }

    @Basic
    @Column(name = "LoaiSanPhamLoaiId", nullable = true)
    public String getLoaiSanPhamLoaiId() {
        return loaiSanPhamLoaiId;
    }

    public void setLoaiSanPhamLoaiId(String loaiSanPhamLoaiId) {
        this.loaiSanPhamLoaiId = loaiSanPhamLoaiId;
    }

    @Basic
    @Column(name = "CuaHangId", nullable = true)
    public String getCuaHangId() {
        return cuaHangId;
    }

    public void setCuaHangId(String cuaHangId) {
        this.cuaHangId = cuaHangId;
    }

    @Basic
    @Column(name = "NgayDang", nullable = false)
    public Date getNgayDang() {
        return ngayDang;
    }

    public void setNgayDang(Date ngayDang) {
        this.ngayDang = ngayDang;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        SanPham sanPham = (SanPham) o;
        return Objects.equals(sanPhamId, sanPham.sanPhamId) && Objects.equals(tenSanPham, sanPham.tenSanPham) && Objects.equals(moTa, sanPham.moTa) && Objects.equals(tonKho, sanPham.tonKho) && Objects.equals(donGia, sanPham.donGia) && Objects.equals(donVi, sanPham.donVi) && Objects.equals(loaiSanPhamLoaiId, sanPham.loaiSanPhamLoaiId) && Objects.equals(cuaHangId, sanPham.cuaHangId) && Objects.equals(ngayDang, sanPham.ngayDang);
    }

    @Override
    public int hashCode() {
        return Objects.hash(sanPhamId, tenSanPham, moTa, tonKho, donGia, donVi, loaiSanPhamLoaiId, cuaHangId, ngayDang);
    }

    @JsonBackReference
    @OneToMany(mappedBy = "sanPhamBySanPhamId")
    public Collection<DonHangSanPham> getDonHangSanPhamsBySanPhamId() {
        return donHangSanPhamsBySanPhamId;
    }

    public void setDonHangSanPhamsBySanPhamId(Collection<DonHangSanPham> donHangSanPhamsBySanPhamId) {
        this.donHangSanPhamsBySanPhamId = donHangSanPhamsBySanPhamId;
    }

    @JsonManagedReference
    @ManyToOne(optional=false)
    @JoinColumn(name = "LoaiSanPhamLoaiId", referencedColumnName = "LoaiId", insertable = false, updatable = false)
    public LoaiSanPham getLoaiSanPhamByLoaiSanPhamLoaiId() {
        return loaiSanPhamByLoaiSanPhamLoaiId;
    }

    public void setLoaiSanPhamByLoaiSanPhamLoaiId(LoaiSanPham loaiSanPhamByLoaiSanPhamLoaiId) {
        this.loaiSanPhamByLoaiSanPhamLoaiId = loaiSanPhamByLoaiSanPhamLoaiId;
    }

    @JsonManagedReference
    @ManyToOne(optional=false)
    @JoinColumn(name = "CuaHangId", referencedColumnName = "CuaHangId", insertable = false, updatable = false)
    public CuaHang getCuaHangByCuaHangId() {
        return cuaHangByCuaHangId;
    }

    public void setCuaHangByCuaHangId(CuaHang cuaHangByCuaHangId) {
        this.cuaHangByCuaHangId = cuaHangByCuaHangId;
    }
}
