using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;
using Swim.Domain.Utils;


namespace Swim.Domain.Models.Registration
{
    public class Registration : Entity<int>
    {
        public Participant Participant { get; set; }
        public Trial Trial { get; set; }
    }
}
