package swim;


import Repositories.ParticipantRepositories.ParticipantDatabaseRepository;
import Repositories.ParticipantRepositories.ParticipantRepository;
import Repositories.RegistrationRepositories.RegistrationDatabaseRepository;
import Repositories.RegistrationRepositories.RegistrationRepository;
import Repositories.TrialRepositories.TrialDatabaseRepository;
import Repositories.TrialRepositories.TrialRepository;
import Repositories.UserRepositories.UserDatabaseRepository;
import Repositories.UserRepositories.UserRepository;
import Utils.AbstractServer;
import Utils.RpcConcurrentServer;
import Utils.ServerException;
import swim.Server.ChatServicesImpl;

import java.io.IOException;
import java.util.Properties;

public class StartRpcServer {
    private static int defaultPort=55555;
    public static void main(String[] args) {
        // UserRepository userRepo=new UserRepositoryMock();

        Properties serverProps=new Properties();
        try {
            serverProps.load(StartRpcServer.class.getResourceAsStream("/server.properties"));
            System.out.println("Server properties set. ");
            serverProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find server.properties "+e);
            return;
        }

        UserRepository userRepository= new UserDatabaseRepository();
        ParticipantRepository participantRepository= new ParticipantDatabaseRepository();
        TrialRepository trialRepository = new TrialDatabaseRepository();
        RegistrationRepository registrationRepository = new RegistrationDatabaseRepository();

        IChatServices chatServerImpl=new ChatServicesImpl(userRepository, participantRepository, registrationRepository, trialRepository);
        int chatServerPort=defaultPort;
        try {
            chatServerPort = Integer.parseInt(serverProps.getProperty("server.port"));
        }catch (NumberFormatException nef){
            System.err.println("Wrong  Port Number"+nef.getMessage());
            System.err.println("Using default port "+defaultPort);
        }
        System.out.println("Starting server on port: "+chatServerPort);
        AbstractServer server = new RpcConcurrentServer(chatServerPort, chatServerImpl);
        try {
            server.start();
        } catch (ServerException e) {
            System.err.println("Error starting the server" + e.getMessage());
        }finally {
            try {
                server.stop();
            }catch(ServerException e){
                System.err.println("Error stopping server "+e.getMessage());
            }
        }
    }
}
