package Repositories.UserRepositories;

import Models.User;
import Repositories.CrudRepository;

public interface UserRepository extends CrudRepository<Integer, User> {
    User findBy(String username, String password);
}
