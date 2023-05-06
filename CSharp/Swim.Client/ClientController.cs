using Swim.Domain.Models.UserModels;
using Swim.Services;

namespace Swim.Client
{
    public class ClientController : IChatObserver
    {
        public event EventHandler<UserEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly IChatServices server;
        private User currentUser;
        public ClientController(IChatServices server)
        {
            this.server = server;
            currentUser = null;
        }

        public void Login(String username, String pass)
        {
            User user = new User { 
            Username = username,
            Password = pass
            };
            server.login(user, this);
            Console.WriteLine("Login succeeded ....");
            currentUser = user;
            Console.WriteLine("Current user {0}", user);
        }

        public void logout()
        {
            Console.WriteLine("Ctrl logout");
            server.logout(currentUser, this);
            currentUser = null;
        }

        protected virtual void OnUserEvent(UserEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }
    }
}
