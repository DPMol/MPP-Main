using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.Data.Repositories.ParticipantRepositories
{
    public interface IParticipantRepository : IRepository<int, Participant>
    {
        List<Participant> FindBy(int trialId);
    }
}
