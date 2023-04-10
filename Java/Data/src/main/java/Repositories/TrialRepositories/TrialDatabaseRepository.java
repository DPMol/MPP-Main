package Repositories.TrialRepositories;

import Models.Trial;
import Repositories.DatabaseRepository;

public class TrialDatabaseRepository extends DatabaseRepository implements TrialRepository {
    @Override
    public Trial findOne(Integer integer) {
        return null;
    }

    @Override
    public Iterable<Trial> findAll() {
        return null;
    }

    @Override
    public Boolean save(Trial entity) {
        return null;
    }

    @Override
    public Boolean delete(Integer integer) {
        return null;
    }

    @Override
    public Boolean update(Trial entity) {
        return null;
    }
}
