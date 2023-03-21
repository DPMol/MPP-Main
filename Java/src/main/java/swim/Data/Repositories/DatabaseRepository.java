package swim.Data.Repositories;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import swim.Data.Utils.DatabaseConnection;
import swim.Domain.Utils.Entity;

public abstract class DatabaseRepository<ID, E extends Entity<ID>> implements Repository<ID, E>{
    protected static DatabaseConnection connection = DatabaseConnection.getInstance();
    protected static Logger logger = LogManager.getLogger("DatabaseRepository");
}
