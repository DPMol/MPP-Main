using Swim.Domain.Models.TrialModels;
using Swim.Domain.Utils;

namespace Swim.Domain.Models.ParticipantModels
{
    public class Participant : Entity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Trial> Trials { get; set; }
    }
}
