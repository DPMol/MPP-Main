using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.Registration;
using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;
using System.Data.SqlClient;

namespace Swim.Data.Repositories.RegistrationRepositories
{
    public class RegistrationRepository : DatabaseRepository, IRegistrationRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> FindAll()
        {
            throw new NotImplementedException();
        }

        public Registration? FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Registration entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Registration entity)
        {
            throw new NotImplementedException();
        }
    }
}
