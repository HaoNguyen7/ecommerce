package r06.mall.Responses;

import java.util.List;

import r06.mall.Repositories.Report;

public class ReportResponse {
    public boolean status;
    public String message;
    public List<Report> data;

    public ReportResponse(boolean status, String message, List<Report> data) {
        this.status = status;
        this.message = message;
        this.data = data;
    }

    public ReportResponse(boolean status) {
        this.status = status;
    }
}
