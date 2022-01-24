package r06.mall.Controllers;

import java.util.Collection;
import java.util.List;
import java.util.Optional;

import javax.websocket.server.PathParam;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import r06.mall.JwtParser.JwtParser;
import r06.mall.Responses.ImportantItemsResponse;
import r06.mall.Services.ImportantItemsService;
import r06.mall.Repositories.Item;



@RestController
public class ImportantItemsController {
    private final ImportantItemsService importantItemsService;

    @Autowired
    public ImportantItemsController(ImportantItemsService importantItemsService){
        this.importantItemsService = importantItemsService;
    }

    @GetMapping("/importantItems")
    public ResponseEntity<ImportantItemsResponse> getImportantItems(){
        List<Item> list = importantItemsService.getImportantItems();
        return new ResponseEntity<ImportantItemsResponse>(new ImportantItemsResponse(list), HttpStatus.OK);
    }
    
}
