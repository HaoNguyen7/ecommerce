package r06.mall.Models;

import com.fasterxml.jackson.annotation.JsonBackReference;

import javax.persistence.*;
import java.util.Collection;
import java.util.Objects;

@Entity
@Table(name="CuaHang")
public class CuaHang {
    private String cuaHangId;
    private String tenCuaHang;
    private String moTa;
    private String danhGia;
    private String stk;
    private String soDienThoai;
    private Double kinhDo;
    private Double viDo;
    private Collection<SanPham> sanPhamsByCuaHangId;

    @Id
    @Column(name = "CuaHangId", nullable = false)
    public String getCuaHangId() {
        return cuaHangId;
    }

    public void setCuaHangId(String cuaHangId) {
        this.cuaHangId = cuaHangId;
    }

    @Basic
    @Column(name = "TenCuaHang", nullable = false, length = 50)
    public String getTenCuaHang() {
        return tenCuaHang;
    }

    public void setTenCuaHang(String tenCuaHang) {
        this.tenCuaHang = tenCuaHang;
    }

    @Basic
    @Column(name = "MoTa", nullable = true, length = 255)
    public String getMoTa() {
        return moTa;
    }

    public void setMoTa(String moTa) {
        this.moTa = moTa;
    }

    @Basic
    @Column(name = "DanhGia", nullable = true, length = 50)
    public String getDanhGia() {
        return danhGia;
    }

    public void setDanhGia(String danhGia) {
        this.danhGia = danhGia;
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
    @Column(name = "SoDienThoai", nullable = false, length = 10)
    public String getSoDienThoai() {
        return soDienThoai;
    }

    public void setSoDienThoai(String soDienThoai) {
        this.soDienThoai = soDienThoai;
    }

    @Basic
    @Column(name = "KinhDo", nullable = false, precision = 0)
    public Double getKinhDo() {
        return kinhDo;
    }

    public void setKinhDo(Double kinhDo) {
        this.kinhDo = kinhDo;
    }

    @Basic
    @Column(name = "ViDo", nullable = false, precision = 0)
    public Double getViDo() {
        return viDo;
    }

    public void setViDo(Double viDo) {
        this.viDo = viDo;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        CuaHang cuaHang = (CuaHang) o;
        return Objects.equals(cuaHangId, cuaHang.cuaHangId) && Objects.equals(tenCuaHang, cuaHang.tenCuaHang) && Objects.equals(moTa, cuaHang.moTa) && Objects.equals(danhGia, cuaHang.danhGia) && Objects.equals(stk, cuaHang.stk) && Objects.equals(soDienThoai, cuaHang.soDienThoai) && Objects.equals(kinhDo, cuaHang.kinhDo) && Objects.equals(viDo, cuaHang.viDo);
    }

    @Override
    public int hashCode() {
        return Objects.hash(cuaHangId, tenCuaHang, moTa, danhGia, stk, soDienThoai, kinhDo, viDo);
    }

    @JsonBackReference
    @OneToMany(mappedBy = "cuaHangByCuaHangId")
    public Collection<SanPham> getSanPhamsByCuaHangId() {
        return sanPhamsByCuaHangId;
    }

    public void setSanPhamsByCuaHangId(Collection<SanPham> sanPhamsByCuaHangId) {
        this.sanPhamsByCuaHangId = sanPhamsByCuaHangId;
    }
}
