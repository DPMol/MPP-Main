package Repositories.TrialRepositories;

import Models.Trial;
import Models.User;
import Repositories.DatabaseRepository;

import java.util.ArrayList;
import java.util.List;

public class TrialDatabaseRepository extends DatabaseRepository implements TrialRepository {
    @Override
    public Trial findOne(Integer integer) {
        return null;
    }

    @Override
    public List<Trial> findAll() {
        logger.info("Searching all trials");
        String queryString = "SELECT *  FROM  Trials";

        try(var statement = connection.Get().prepareStatement(queryString)) {
            var trials = new ArrayList<Trial>();

            var results = statement.executeQuery();
            while (results.next())
            {
                var id = results.getInt("id");
                var distance = results.getInt("distance");
                var style = results.getString("style");

                var trial = new Trial(id, distance, style);

                trials.add(trial);
            }

            logger.info("Search Finished With {} results", trials.size());
            return trials;
        }
        catch (Exception e){
            throw new RuntimeException(e);
        }
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
