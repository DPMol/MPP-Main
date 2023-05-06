using Swim.Domain.Models.ParticipantModels;

namespace Swim.Data.Repositories.ParticipantRepositories
{
    public interface IParticipantRepository : IRepository<int, Participant>
    {
        List<Participant> FindBy(int trialId);
    }
}
