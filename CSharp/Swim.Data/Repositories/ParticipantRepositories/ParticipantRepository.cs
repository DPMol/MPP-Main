using Swim.Data.Repositories.RegistrationRepositories;
using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.Data.Repositories.ParticipantRepositories
{
    public class ParticipantRepository : DatabaseRepository, IParticipantRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Participant> FindBy(int trialId)
        {
            throw new NotImplementedException();
        }

        public Participant? FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Participant entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Participant entity)
        {
            throw new NotImplementedException();
        }
    }
}
