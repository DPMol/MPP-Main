using Swim.Domain.Models.UserModels;

namespace Swim.Data.Repositories.UserRepositories
{
    public interface IUserRepository : IRepository<int, User>
    {
        User? FindBy(String username, String password);
    }
}
