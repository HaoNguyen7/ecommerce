package r06.mall.Models;

import com.fasterxml.jackson.annotation.JsonBackReference;

import javax.persistence.*;
import java.util.Collection;
import java.util.Objects;

@Entity
@Table(name = "CuaHang")
public class CuaHang {
    private String cuaHangId;
    private String tenCuaHang;
    private String moTa;
    private String danhGia;
    private String stk;
    private String soDienThoai;
    private Double kinhDo;
    private Double viDo;
    private String maSoThue;
    private Boolean tinhTrang;
    private String userId;
    private String diaChi;
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
    @Column(name = "DiaChi", nullable = true, length = 100)
    public String getDiaChi() {
        return diaChi;
    }

    public void setDiaChi(String diaChi) {
        this.diaChi = diaChi;
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

    @Basic
    @Column(name = "MaSoThue", nullable = false, precision = 0)
    public String getMaSoThue() {
        return maSoThue;
    }

    public void setMaSoThue(String maSoThue) {
        this.maSoThue = maSoThue;
    }

    @Basic
    @Column(name = "TinhTrang", nullable = false, precision = 0)
    public Boolean getTinhTrang() {
        return tinhTrang;
    }

    public void setTinhTrang(Boolean tinhTrang) {
        this.tinhTrang = tinhTrang;
    }

    @Basic
    @Column(name = "UserId", nullable = false, precision = 0)
    public String getUserId() {
        return userId;
    }

    public void setUserId(String userId) {
        this.userId = userId;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        CuaHang other = (CuaHang) obj;
        if (cuaHangId == null) {
            if (other.cuaHangId != null)
                return false;
        } else if (!cuaHangId.equals(other.cuaHangId))
            return false;
        if (danhGia == null) {
            if (other.danhGia != null)
                return false;
        } else if (!danhGia.equals(other.danhGia))
            return false;
        if (kinhDo == null) {
            if (other.kinhDo != null)
                return false;
        } else if (!kinhDo.equals(other.kinhDo))
            return false;
        if (maSoThue == null) {
            if (other.maSoThue != null)
                return false;
        } else if (!maSoThue.equals(other.maSoThue))
            return false;
        if (moTa == null) {
            if (other.moTa != null)
                return false;
        } else if (!moTa.equals(other.moTa))
            return false;
        if (sanPhamsByCuaHangId == null) {
            if (other.sanPhamsByCuaHangId != null)
                return false;
        } else if (!sanPhamsByCuaHangId.equals(other.sanPhamsByCuaHangId))
            return false;
        if (soDienThoai == null) {
            if (other.soDienThoai != null)
                return false;
        } else if (!soDienThoai.equals(other.soDienThoai))
            return false;
        if (stk == null) {
            if (other.stk != null)
                return false;
        } else if (!stk.equals(other.stk))
            return false;
        if (tenCuaHang == null) {
            if (other.tenCuaHang != null)
                return false;
        } else if (!tenCuaHang.equals(other.tenCuaHang))
            return false;
        if (tinhTrang == null) {
            if (other.tinhTrang != null)
                return false;
        } else if (!tinhTrang.equals(other.tinhTrang))
            return false;
        if (userId == null) {
            if (other.userId != null)
                return false;
        } else if (!userId.equals(other.userId))
            return false;
        if (viDo == null) {
            if (other.viDo != null)
                return false;
        } else if (!viDo.equals(other.viDo))
            return false;
        return true;
    }

    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result + ((cuaHangId == null) ? 0 : cuaHangId.hashCode());
        result = prime * result + ((danhGia == null) ? 0 : danhGia.hashCode());
        result = prime * result + ((kinhDo == null) ? 0 : kinhDo.hashCode());
        result = prime * result + ((maSoThue == null) ? 0 : maSoThue.hashCode());
        result = prime * result + ((moTa == null) ? 0 : moTa.hashCode());
        result = prime * result + ((sanPhamsByCuaHangId == null) ? 0 : sanPhamsByCuaHangId.hashCode());
        result = prime * result + ((soDienThoai == null) ? 0 : soDienThoai.hashCode());
        result = prime * result + ((stk == null) ? 0 : stk.hashCode());
        result = prime * result + ((tenCuaHang == null) ? 0 : tenCuaHang.hashCode());
        result = prime * result + ((tinhTrang == null) ? 0 : tinhTrang.hashCode());
        result = prime * result + ((userId == null) ? 0 : userId.hashCode());
        result = prime * result + ((viDo == null) ? 0 : viDo.hashCode());
        return result;
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
