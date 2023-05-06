using Swim.Domain.Utils;

namespace Swim.Domain.Models.UserModels
{
    [Serializable]
    public class UserDTO : Entity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
