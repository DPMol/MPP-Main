using Swim.Domain.Utils;

namespace Swim.Domain.Models.UserModels
{
    public class User : Entity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
