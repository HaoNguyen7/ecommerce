package r06.mall.Models;

import com.fasterxml.jackson.annotation.JsonBackReference;

import javax.persistence.*;
import java.util.Collection;
import java.util.Objects;

@Entity
@Table(name="LoaiSanPham")
public class LoaiSanPham {
    private String loaiId;
    private String ten;
    private Collection<SanPham> sanPhamsByLoaiId;

    @Id
    @Column(name = "LoaiId", nullable = false)
    public String getLoaiId() {
        return loaiId;
    }

    public void setLoaiId(String loaiId) {
        this.loaiId = loaiId;
    }

    @Basic
    @Column(name = "Ten", nullable = true, length = 50)
    public String getTen() {
        return ten;
    }

    public void setTen(String ten) {
        this.ten = ten;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        LoaiSanPham that = (LoaiSanPham) o;
        return Objects.equals(loaiId, that.loaiId) && Objects.equals(ten, that.ten);
    }

    @Override
    public int hashCode() {
        return Objects.hash(loaiId, ten);
    }

    @JsonBackReference
    @OneToMany(mappedBy = "loaiSanPhamByLoaiSanPhamLoaiId")
    public Collection<SanPham> getSanPhamsByLoaiId() {
        return sanPhamsByLoaiId;
    }

    public void setSanPhamsByLoaiId(Collection<SanPham> sanPhamsByLoaiId) {
        this.sanPhamsByLoaiId = sanPhamsByLoaiId;
    }
}
