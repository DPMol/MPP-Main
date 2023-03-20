using Swim.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripApp.domain;
using TripApp.repo;

namespace Swim.repo
{
    public abstract class DabataseRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
    {
        protected readonly DatabaseConnection _connection = DatabaseConnection.Instance;
        public abstract bool Delete(ID id);
        public abstract IEnumerable<E> FindAll();
        public abstract E? FindOne(ID id);
        public abstract bool Save(E entity);
        public abstract bool Update(E entity);
    }
}
