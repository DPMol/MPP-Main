using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;
using Swim.Domain.Utils;


namespace Swim.Domain.Models.Registration
{
    public class Registration : Entity<int>
    {
        public User User { get; set; }
        public Trial Trial { get; set; }
    }
}
