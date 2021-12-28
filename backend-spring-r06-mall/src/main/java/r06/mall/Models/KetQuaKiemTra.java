package r06.mall.Models;

import javax.persistence.*;
import java.sql.Date;
import java.util.Objects;

@Entity
@Table(name="KetQuaKiemTra")
public class KetQuaKiemTra {
    private String ketQuaId;
    private String ketQua;
    private Date ngayKiemTra;
    private String nguoiGiaoHangNguoiGiaoId;
    private NguoiGiaoHang nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId;

    @Id
    @Column(name = "KetQuaId", nullable = false)
    public String getKetQuaId() {
        return ketQuaId;
    }

    public void setKetQuaId(String ketQuaId) {
        this.ketQuaId = ketQuaId;
    }

    @Basic
    @Column(name = "KetQua", nullable = false, length = 50)
    public String getKetQua() {
        return ketQua;
    }

    public void setKetQua(String ketQua) {
        this.ketQua = ketQua;
    }

    @Basic
    @Column(name = "NgayKiemTra", nullable = false)
    public Date getNgayKiemTra() {
        return ngayKiemTra;
    }

    public void setNgayKiemTra(Date ngayKiemTra) {
        this.ngayKiemTra = ngayKiemTra;
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
        KetQuaKiemTra that = (KetQuaKiemTra) o;
        return Objects.equals(ketQuaId, that.ketQuaId) && Objects.equals(ketQua, that.ketQua) && Objects.equals(ngayKiemTra, that.ngayKiemTra) && Objects.equals(nguoiGiaoHangNguoiGiaoId, that.nguoiGiaoHangNguoiGiaoId);
    }

    @Override
    public int hashCode() {
        return Objects.hash(ketQuaId, ketQua, ngayKiemTra, nguoiGiaoHangNguoiGiaoId);
    }

    @ManyToOne(optional=false)
    @JoinColumn(name = "NguoiGiaoHangNguoiGiaoId", referencedColumnName = "NguoiGiaoId", insertable = false, updatable = false)
    public NguoiGiaoHang getNguoiGiaoHangByNguoiGiaoHangNguoiGiaoId() {
        return nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId;
    }

    public void setNguoiGiaoHangByNguoiGiaoHangNguoiGiaoId(NguoiGiaoHang nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId) {
        this.nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId = nguoiGiaoHangByNguoiGiaoHangNguoiGiaoId;
    }
}
