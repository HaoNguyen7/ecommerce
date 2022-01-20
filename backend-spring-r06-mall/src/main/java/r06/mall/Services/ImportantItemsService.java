package r06.mall.Services;

import java.util.Optional;

import org.springframework.stereotype.Service;

import r06.mall.Repositories.ImportantItemsRepository;

@Service
public class ImportantItemsService {
    private final ImportantItemsRepository importantItemsRepository;

    public ImportantItemsService(ImportantItemsRepository importantItemsRepository) {
        this.importantItemsRepository = importantItemsRepository;
    }
}