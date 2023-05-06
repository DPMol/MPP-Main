using Swim.Domain.Models.TrialModels;
using Swim.Domain.Utils;

namespace Swim.Domain.Models.ParticipantModels
{
    [Serializable]
    public class ParticipantDTO : Entity<int>
    {
        string Name { get; set; }
        int Age { get; set; }
        TrialDTO[] ?Trials { get; set; }
    }
}
