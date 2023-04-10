package swim.Server;

import Models.User;
import Repositories.ParticipantRepositories.ParticipantRepository;
import Repositories.RegistrationRepositories.RegistrationRepository;
import Repositories.TrialRepositories.TrialRepository;
import Repositories.UserRepositories.UserRepository;

import swim.ChatException;
import swim.IChatObserver;
import swim.IChatServices;

import java.util.Map;
import java.util.Set;
import java.util.TreeSet;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;


public class ChatServicesImpl implements IChatServices {

    private UserRepository userRepository;
    private ParticipantRepository participantRepositoryRepository;
    private RegistrationRepository registrationRepository;
    private TrialRepository trialRepository;
    private Map<Integer, IChatObserver> loggedClients;

    public ChatServicesImpl(UserRepository userRepository, ParticipantRepository participantRepositoryRepository, RegistrationRepository registrationRepository, TrialRepository trialRepository) {
        this.userRepository = userRepository;
        this.participantRepositoryRepository = participantRepositoryRepository;
        this.registrationRepository = registrationRepository;
        this.trialRepository = trialRepository;
        loggedClients=new ConcurrentHashMap<>();
    }


    public synchronized void login(User user, IChatObserver client) throws ChatException {
        User userR=userRepository.findBy(user.getUsername(),user.getPassword());
        if (userR!=null){
            if(loggedClients.get(user.getId())!=null)
                throw new ChatException("User already logged in.");
            loggedClients.put(user.getId(), client);
        }else
            throw new ChatException("Authentication failed.");
    }


    private final int defaultThreadsNo=5;


    public synchronized void logout(User user, IChatObserver client) throws ChatException {
        IChatObserver localClient=loggedClients.remove(user.getId());
        if (localClient==null)
            throw new ChatException("User "+user.getId()+" is not logged in.");
    }

}
