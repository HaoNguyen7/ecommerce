package r06.mall.Responses;

import java.util.List;

import r06.mall.Repositories.Commision;

public class HoaHongResponse {
    public boolean status;
    public String message;
    public List<Commision> data;

    public HoaHongResponse(boolean status, String message, List<Commision> data) {
        this.status = status;
        this.message = message;
        this.data = data;
    }

    public HoaHongResponse(boolean status) {
        this.status = status;
    }
}
