package Repositories.ParticipantRepositories;

import Models.Participant;
import Models.Trial;
import Repositories.DatabaseRepository;

import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class ParticipantDatabaseRepository extends DatabaseRepository implements ParticipantRepository {
    @Override
    public Participant findOne(Integer integer) {
        return null;
    }

    @Override
    public List<Participant> findAll() {
        return null;
    }

    @Override
    public List<Participant> findBy(Integer trialId){
        logger.info("Searching participants for trial{}", trialId);
        String queryString = "SELECT *  FROM  Participants p Where EXISTS(" +
                "SELECT * FROM Registrations WHERE participantId = p.Id and trialId = ?)";

        try(var statement = connection.Get().prepareStatement(queryString)) {
            var participants = new ArrayList<Participant>();
            statement.setInt(1, trialId);

            var results = statement.executeQuery();
            while (results.next())
            {
                var id = results.getInt("id");
                var name = results.getString("name");
                var age = results.getInt("age");

                var participant = new Participant(id, name, age);

                participants.add(participant);
            }

            logger.info("Search Finished With {} results", participants.size());
            return participants;
        }
        catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    private int getLastId(){
        logger.info("Getting last id");
        String queryString = "SELECT SCOPE_IDENTITY() as id";

        try(var statement = connection.Get().prepareStatement(queryString)){
            var result = statement.executeQuery();
            if(result.next()){
                return result.getInt("id");
            }
            else throw new Exception();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    private void saveParticipations(int participantId, List<Trial> trials){
        logger.info("Saving Participantions");
        String queryString = "Insert Into Registrations(participantId, trialId) Values";
        for(int i = 0; i < trials.size() - 1; i++){
            queryString+="(?, ?),";
        }
        queryString+="(?, ?)";

        try{
            var statement = connection.Get().prepareStatement(queryString);
            int pozition = 1;
            for (var trial:
                 trials) {
                statement.setInt(pozition, participantId);
                statement.setInt(pozition+1, trial.getId());
                pozition += 2;
            }

            var result = statement.executeUpdate() > 0;

            if (result)
            {
                logger.info("Save Successful");
            }
            else
            {
                logger.warn("Save failed");
            }
        }
        catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public Boolean save(Participant entity) {
        logger.info("Saving Participant:");
        String queryString = "Insert Into Participants(name, age) Values(?, ?)";

        try{
            var statement = connection.Get().prepareStatement(queryString, Statement.RETURN_GENERATED_KEYS);
            statement.setString(1, entity.getName());
            statement.setInt(2, entity.getAge());

            var result = statement.executeUpdate() > 0;


            if (result)
            {
                logger.info("Save Successful");
                var rs = statement.getGeneratedKeys();
                if(rs.next()){
                    var id = rs.getInt(1);
                    saveParticipations(id, entity.getTrials());
                }

            }
            else
            {
                logger.warn("Save failed");
            }

            return result;
        }
        catch (Exception e) {
            throw new RuntimeException(e);
        }
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
