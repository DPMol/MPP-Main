package server.Server;

import Models.Participant;
import Models.Trial;
import Models.User;
import Repositories.ParticipantRepositories.ParticipantRepository;
import Repositories.RegistrationRepositories.RegistrationRepository;
import Repositories.TrialRepositories.TrialRepository;
import Repositories.UserRepositories.UserRepository;
import services.SwimException;
import services.IChatObserver;
import services.IChatServices;

import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;


public class ChatServicesImpl implements IChatServices {

    private UserRepository userRepository;
    private ParticipantRepository participantRepository;
    private RegistrationRepository registrationRepository;
    private TrialRepository trialRepository;
    private Map<Integer, IChatObserver> loggedClients;

    public ChatServicesImpl(UserRepository userRepository, ParticipantRepository participantRepositoryRepository, RegistrationRepository registrationRepository, TrialRepository trialRepository) {
        this.userRepository = userRepository;
        this.participantRepository = participantRepositoryRepository;
        this.registrationRepository = registrationRepository;
        this.trialRepository = trialRepository;
        loggedClients=new ConcurrentHashMap<>();
    }

    public synchronized User login(User user, IChatObserver client) throws SwimException {
        User userR=userRepository.findBy(user.getUsername(),user.getPassword());
        if (userR!=null){
            if(loggedClients.get(userR.getId()) != null)
                throw new SwimException("User already logged in.");
            loggedClients.put(userR.getId(), client);
        }else
            throw new SwimException("Authentication failed.");

        return userR;
    }

    private final int defaultThreadsNo=5;

    public synchronized void logout(User user, IChatObserver client) throws SwimException {
        IChatObserver localClient=loggedClients.remove(user.getId());
        if (localClient==null)
            throw new SwimException("User "+user.getId()+" is not logged in.");
    }

    public synchronized Trial[] getTrials(){
        var trials = trialRepository.findAll();
        return trials.toArray(new Trial[trials.size()]);
    }

    @Override
    public Participant[] getParticipants(Integer trialId) {
        var participants = participantRepository.findBy(trialId);
        return participants.toArray(new Participant[participants.size()]);
    }

    @Override
    public void addParticipant(Participant participant) throws SwimException {
        participantRepository.save(participant);
    }
}
