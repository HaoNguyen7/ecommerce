package r06.mall.Services;

import java.util.List;

import org.springframework.stereotype.Service;

import r06.mall.Repositories.ImportantItemsRepository;
import r06.mall.Repositories.Item;

@Service
public class ImportantItemsService {
    private final ImportantItemsRepository importantItemsRepository;

    public ImportantItemsService(ImportantItemsRepository importantItemsRepository) {
        this.importantItemsRepository = importantItemsRepository;
    }

    public List<Item> getImportantItems(){
        return importantItemsRepository.getImportantItems();
    }
}