package swim.Data.Utils;

import java.sql.Connection;
import java.sql.DriverManager;

public class DatabaseConnection
{
    private static Connection Instance;
    private static final String connectionString = "jdbc:sqlserver://localhost;database=MPP;encrypt=true;trustServerCertificate=true;";
    private static final String username = "admin";
    private static final String password = "admin";
    private Connection connection;

    private static DatabaseConnection instance = null;

    DatabaseConnection() {
        Open();
    }

    public static synchronized DatabaseConnection getInstance()
    {
        if (instance == null)
            instance = new DatabaseConnection();

        return instance;
    }

    private void Open()
    {
        try
        {
            connection = DriverManager.getConnection(connectionString, username, password);
        }
        catch (Exception ex) {
            throw new RuntimeException(ex);
        }
    }

    public Connection Get()
    {
        return connection;
    }
}
