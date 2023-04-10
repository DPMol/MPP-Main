package Repositories;

import Utils.DatabaseConnection;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

public abstract class DatabaseRepository {
    protected static DatabaseConnection connection = DatabaseConnection.getInstance();
    protected static Logger logger = LogManager.getLogger("DatabaseRepository");
}
