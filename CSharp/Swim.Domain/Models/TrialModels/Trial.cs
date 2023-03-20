using Swim.Domain.Utils;

namespace Swim.Domain.Models.TrialModels
{
    public class Trial : Entity<int>
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }
        public DateTime StartTime { get; set; }
    }
}
