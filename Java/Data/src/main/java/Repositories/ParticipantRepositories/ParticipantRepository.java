package Repositories.ParticipantRepositories;


import Models.Participant;
import Models.Trial;
import Repositories.CrudRepository;

import java.util.List;

public interface ParticipantRepository extends CrudRepository<Integer, Participant> {
    List<Participant> findBy(Integer trialId);
}
