using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;

namespace Swim.Services
{
    public interface IChatServices

    {
        void Login(User user, IChatObserver client);
        void Logout(User user, IChatObserver client);

        Trial[] GetTrials();
        Participant[] GetParticipants(Trial trial);
        void AddParticipant(Participant participant);
    }
}
