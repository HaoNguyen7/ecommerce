package r06.mall.Models;

import javax.persistence.*;
import java.sql.Date;
import java.util.Objects;

@Entity
@Table(name="ThongTinDiDuong")
public class ThongTinDiDuong {
    private String tttdId;
    private Date ngayCap;
    private Date ngayHetHan;
    private String nguoiGiaoHangNguoiGiaoId;
    private NguoiGiaoHang nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId;

    @Id
    @Column(name = "TTTDId", nullable = false)
    public String getTttdId() {
        return tttdId;
    }

    public void setTttdId(String tttdId) {
        this.tttdId = tttdId;
    }

    @Basic
    @Column(name = "NgayCap", nullable = false)
    public Date getNgayCap() {
        return ngayCap;
    }

    public void setNgayCap(Date ngayCap) {
        this.ngayCap = ngayCap;
    }

    @Basic
    @Column(name = "NgayHetHan", nullable = false)
    public Date getNgayHetHan() {
        return ngayHetHan;
    }

    public void setNgayHetHan(Date ngayHetHan) {
        this.ngayHetHan = ngayHetHan;
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
        ThongTinDiDuong that = (ThongTinDiDuong) o;
        return Objects.equals(tttdId, that.tttdId) && Objects.equals(ngayCap, that.ngayCap) && Objects.equals(ngayHetHan, that.ngayHetHan) && Objects.equals(nguoiGiaoHangNguoiGiaoId, that.nguoiGiaoHangNguoiGiaoId);
    }

    @Override
    public int hashCode() {
        return Objects.hash(tttdId, ngayCap, ngayHetHan, nguoiGiaoHangNguoiGiaoId);
    }

    @ManyToOne
    @JoinColumn(name = "NguoiGiaoHangNguoiGiaoId", referencedColumnName = "NguoiGiaoId", insertable = false, updatable = false)
    public NguoiGiaoHang getNguoiGiaoHangByNguoiGiaoHangNguoiGiaoId() {
        return nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId;
    }

    public void setNguoiGiaoHangByNguoiGiaoHangNguoiGiaoId(NguoiGiaoHang nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId) {
        this.nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId = nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId;
    }
}
