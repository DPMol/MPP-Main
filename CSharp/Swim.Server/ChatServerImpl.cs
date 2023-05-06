using Swim.Data.Repositories.ParticipantRepositories;
using Swim.Data.Repositories.TrialRepositories;
using Swim.Data.Repositories.UserRepositories;
using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;
using Swim.Services;

namespace Swim.Server
{
    public class ChatServerImpl : IChatServices
    {
        private readonly IUserRepository userRepository = new UserRepository();
        private readonly ITrialRepository trialRepository = new TrialRepository();
        private readonly IParticipantRepository participantRepository = new ParticipantRepository();
        private readonly IDictionary<int, IChatObserver> loggedClients;



        public ChatServerImpl()
        {
            loggedClients = new Dictionary<int, IChatObserver>();
        }

        public void Login(User user, IChatObserver client)
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

        public void Logout(User user, IChatObserver client)
        {
            IChatObserver localClient = loggedClients[user.Id];
            if (localClient == null)
                throw new ChatException("User " + user.Id + " is not logged in.");
            loggedClients.Remove(user.Id);
        }

        public Trial[] GetTrials()
        {
            IEnumerable<Trial> trials = trialRepository.FindAll();
            
            return trials.ToArray();
        }

        public Participant[] GetParticipants(Trial trial)
        {
            IEnumerable<Participant> participants = participantRepository.FindBy(trial.Id);

            return participants.ToArray();
        }

        public void AddParticipant(Participant participant)
        {
            participantRepository.Save(participant);
        }
    }
}
