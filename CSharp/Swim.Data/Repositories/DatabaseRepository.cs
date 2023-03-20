using log4net;
using Swim.Data.Utils;
using Swim.Domain.Utils;

namespace Swim.Data.Repositories
{
    public abstract class DatabaseRepository
    {
        protected readonly DatabaseConnection _connection = DatabaseConnection.Instance;
        protected static readonly ILog _logger = LogManager.GetLogger(typeof(DatabaseRepository));
    }
}
