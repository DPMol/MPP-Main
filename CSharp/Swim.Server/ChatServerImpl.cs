using Swim.Data.Repositories.UserRepositories;
using Swim.Domain.Models.UserModels;
using Swim.Services;

namespace Swim.Server
{
    public class ChatServerImpl : IChatServices
    {
        private IUserRepository userRepository;
        private readonly IDictionary<int, IChatObserver> loggedClients;



        public ChatServerImpl(IUserRepository repo)
        {
            userRepository = repo;
            loggedClients = new Dictionary<int, IChatObserver>();
        }

        public void login(User user, IChatObserver client)
        {
            User userOk = userRepository.FindBy(user.Username, user.Password);
            if (userOk != null)
            {
                if (loggedClients.ContainsKey(user.Id))
                    throw new ChatException("User already logged in.");
                loggedClients[user.Id] = client;
            }
            else
                throw new ChatException("Authentication failed.");
        
        }

        public void logout(User user, IChatObserver client)
        {
            IChatObserver localClient = loggedClients[user.Id];
            if (localClient == null)
                throw new ChatException("User " + user.Id + " is not logged in.");
            loggedClients.Remove(user.Id);
        }

    }
}
