package r06.mall.Responses;
import java.util.List;

import r06.mall.Repositories.Item;

public class ImportantItemsResponse {
    public List<Item> data;
    public ImportantItemsResponse(List<Item> data){
        this.data = data;
    }
}
