package swim;

import swim.Data.Repositories.UserRepositories.UserRepository;
import swim.Domain.Models.User;

public class Main {
    public static void main(String[] args) {
        var repo = new UserRepository();

        repo.save(new User(12, "danial", "daniel"));

        var users = repo.findAll();

        System.out.println(users);
    }
}