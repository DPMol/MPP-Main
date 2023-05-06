using Swim.Domain.Models.UserModels;

namespace Swim.Networking
{
    public interface Request
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
