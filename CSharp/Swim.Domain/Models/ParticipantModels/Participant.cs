using Swim.Domain.Models.TrialModels;
using Swim.Domain.Utils;

namespace Swim.Domain.Models.ParticipantModels
{
    public class Participant : Entity<int>
    {
        string Name { get; set; }
        int Age { get; set; }
        List<Trial> Trials { get; set; }
    }
}
