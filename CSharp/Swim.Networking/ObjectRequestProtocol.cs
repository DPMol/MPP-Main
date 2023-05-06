using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;

namespace Swim.Networking
{
    public interface Request
    {
    }

    [Serializable]
    public class AddParticipantRequest : Request
    {
        public ParticipantDTO participantDTO { get; set; }
    }

    [Serializable]
    public class GetParticipantsRequest : Request
    {
        public TrialDTO TrialDTO { get; set; }
    }

    [Serializable]
    public class GetTrialsRequest : Request
    {

    }

    [Serializable]
    public class LoginRequest : Request
    {
        private UserDTO user;

        public LoginRequest(UserDTO user)
        {
            this.user = user;
        }

        public virtual UserDTO User
        {
            get
            {
                return user;
            }
        }
    }

    [Serializable]
    public class LogoutRequest : Request
    {
        private UserDTO user;

        public LogoutRequest(UserDTO user)
        {
            this.user = user;
        }

        public virtual UserDTO User
        {
            get
            {
                return user;
            }
        }
    }
}
