package swim;

import Repositories.UserRepositories.UserDatabaseRepository;
import Repositories.UserRepositories.UserRepository;

public class Main {
    public static void main(String[] args) {
        UserRepository userRepository = new UserDatabaseRepository();
    }
}