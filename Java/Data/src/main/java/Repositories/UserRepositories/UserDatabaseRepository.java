package Repositories.UserRepositories;

import Models.User;
import Repositories.DatabaseRepository;

import java.util.ArrayList;
import java.util.List;

public class UserDatabaseRepository extends DatabaseRepository implements UserRepository{

    public Boolean delete(Integer id) {
        logger.info("Deleting User: {}", id);
        String queryString = "Delete From Users Where id = ?";

        try{
            var statement = connection.Get().prepareStatement(queryString);
            statement.setInt(1, id);

            var result = statement.executeUpdate() > 0;

            if (result)
            {
                logger.info("Delete Successful");
            }
            else
            {
                logger.warn("Delete Failed");
            }

            return result;
        }
        catch(Exception e){
            throw new RuntimeException(e);
        }
    }

    public List<User> findAll() {
        logger.info("Searching all users");
        String queryString = "SELECT *  FROM  Users";

        try(var statement = connection.Get().prepareStatement(queryString)) {
            var users = new ArrayList<User>();

            var results = statement.executeQuery();
            while (results.next())
            {
                var id = results.getInt("id");
                var username = results.getString("username");
                var password = results.getString("password");

                var user = new User(id, username, password);

                users.add(user);
            }

            logger.info("Search Finished With {} results", users.size());
            return users;
        }
        catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    public User findOne(Integer id)
    {
        logger.info("Searching User: {}", id);
        String queryString = "SELECT *  FROM  Users where id = ?";

        try (var statement = connection.Get().prepareStatement(queryString)){
            statement.setInt(1, id);

            var results = statement.executeQuery();

            if (results.next())
            {
                logger.info("User Found");

                var username = results.getString("username");
                var password = results.getString("password");

                return new User(id, username, password);
            }
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
        return null;
    }

    public Boolean save(User entity)
    {
        logger.info("Saving User: {}", entity.getId());
        String queryString = "Insert Into Users(username, password) Values(?, ?)";

        try{
            var statement = connection.Get().prepareStatement(queryString);
            statement.setString(1, entity.getUsername());
            statement.setString(2, entity.getPassword());

            var result = statement.executeUpdate() > 0;

            if (result)
            {
                logger.info("Save Successful");
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

    public Boolean update(User entity)
    {
        logger.info("Updating User: {}", entity.getId());
        String queryString = "Update Users set username = ?, password = ? Where id = ?";

        try{
            var statement = connection.Get().prepareStatement(queryString);
            statement.setString(1, entity.getUsername());
            statement.setString(2, entity.getPassword());
            statement.setInt(3, entity.getId());

            var result = statement.executeUpdate() > 0;

            if (result)
            {
                logger.info("Update Successful");
            }
            else
            {
                logger.warn("Update failed");
            }

            return result;
        }
        catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public User findBy(String username, String password) {
        logger.info("Searching User: {}", username);
        String queryString = "SELECT *  FROM  Users where username = ? and password = ?";

        try (var statement = connection.Get().prepareStatement(queryString)){
            statement.setString(1, username);
            statement.setString(2, password);

            var results = statement.executeQuery();

            if (results.next())
            {
                logger.info("User Found");

                var id = results.getInt("id");

                return new User(id, username, password);
            }
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
        return null;
    }
}
