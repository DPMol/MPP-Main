using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.TrialModels;

namespace Swim.Networking
{
    public interface Response
    {
    }

    [Serializable]
    public class GetParticipantsResponse : Response
    {
        public ParticipantDTO[] participantDTOs { get; set; }
    }

    [Serializable]
    public class GetTrialsResponse : Response
    {
        public TrialDTO[] trialDTOs { get; set; }
    }

    [Serializable]
    public class OkResponse : Response
    {

    }

    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }
    public interface UpdateResponse : Response
    {
    }
}
