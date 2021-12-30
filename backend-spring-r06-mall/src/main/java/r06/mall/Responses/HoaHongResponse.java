package r06.mall.Responses;

import java.util.List;

import r06.mall.Repositories.Commission;

public class HoaHongResponse {
    public boolean status;
    public String message;
    public List<Commission> data;

    public HoaHongResponse(boolean status, String message, List<Commission> data) {
        this.status = status;
        this.message = message;
        this.data = data;
    }

    public HoaHongResponse(boolean status) {
        this.status = status;
    }
}
