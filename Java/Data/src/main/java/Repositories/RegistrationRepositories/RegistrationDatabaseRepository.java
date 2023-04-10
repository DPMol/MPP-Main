package Repositories.RegistrationRepositories;

import Models.Registration;
import Repositories.DatabaseRepository;

public class RegistrationDatabaseRepository extends DatabaseRepository implements RegistrationRepository {
    @Override
    public Registration findOne(Integer integer) {
        return null;
    }

    @Override
    public Iterable<Registration> findAll() {
        return null;
    }

    @Override
    public Boolean save(Registration entity) {
        return null;
    }

    @Override
    public Boolean delete(Integer integer) {
        return null;
    }

    @Override
    public Boolean update(Registration entity) {
        return null;
    }
}
