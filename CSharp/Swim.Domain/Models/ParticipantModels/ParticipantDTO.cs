using Swim.Domain.Models.TrialModels;
using Swim.Domain.Utils;

namespace Swim.Domain.Models.ParticipantModels
{
    [Serializable]
    public class ParticipantDTO : Entity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public TrialDTO[] ?Trials { get; set; }
    }
}
