using Swim.Domain.Models.UserModels;

namespace Swim.Services
{
    public interface IChatServices

    {
        void login(User user, IChatObserver client);
        void logout(User user, IChatObserver client);
    }
}
