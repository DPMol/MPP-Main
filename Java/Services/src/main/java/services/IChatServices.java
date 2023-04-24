package services;

import Models.Participant;
import Models.Trial;
import Models.User;

import java.util.List;

public interface IChatServices {
    User login(User user, IChatObserver client) throws SwimException;
    void logout(User user, IChatObserver client) throws SwimException;
    Trial[] getTrials() throws SwimException;
    Participant[] getParticipants(Integer trialId) throws SwimException;

    void addParticipant(Participant participant) throws SwimException;
}
