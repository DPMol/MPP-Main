package Utils;

import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.util.Properties;

public class DatabaseConnection
{
    private static Connection Instance;
    private static final String connectionString = "jdbc:sqlserver://localhost;database=MPP;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
    private static final String username = "admin";
    private static final String password = "admin";

    private Properties props;

    private Connection connection;

    private static DatabaseConnection instance = null;

    DatabaseConnection() {
        LoadProperties();
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
        String driver = props.getProperty("jdbc.driver");
        String url = props.getProperty("jdbc.url");
        String user = props.getProperty("jdbc.username");
        String pass = props.getProperty("jdbc.password");

        try
        {
            Class.forName(driver);
            connection = DriverManager.getConnection(url, user, pass);
        }
        catch (Exception ex) {
            throw new RuntimeException(ex);
        }
    }

    public Connection Get()
    {
        return connection;
    }

    private void LoadProperties(){
        Properties props = new Properties();
        try {
            props.load(DatabaseConnection.class.getResourceAsStream("/data.properties"));
            System.out.println("Server properties set. ");
            props.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find chatserver.properties "+e);
        }

        this.props = props;
    }
}
