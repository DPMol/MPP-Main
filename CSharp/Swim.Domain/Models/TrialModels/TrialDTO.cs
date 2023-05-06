using Swim.Domain.Utils;

namespace Swim.Domain.Models.TrialModels
{
    [Serializable]
    public class TrialDTO : Entity<int>
    {
        public int Distance { get; set; }
        public string Style { get; set; }
    }
}
