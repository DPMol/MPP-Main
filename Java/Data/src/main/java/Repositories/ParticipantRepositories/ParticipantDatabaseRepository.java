package Repositories.ParticipantRepositories;

import Models.Participant;
import Repositories.DatabaseRepository;

public class ParticipantDatabaseRepository extends DatabaseRepository implements ParticipantRepository {
    @Override
    public Participant findOne(Integer integer) {
        return null;
    }

    @Override
    public Iterable<Participant> findAll() {
        return null;
    }

    @Override
    public Boolean save(Participant entity) {
        return null;
    }

    @Override
    public Boolean delete(Integer integer) {
        return null;
    }

    @Override
    public Boolean update(Participant entity) {
        return null;
    }
}
