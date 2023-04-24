package dto;

import Models.Participant;
import Models.Trial;
import Models.User;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class DTOUtils {

    public static Participant getFromDTO(ParticipantDTO participantDTO){
        var id = participantDTO.getId();
        var name = participantDTO.getName();
        var age = participantDTO.getAge();
        var trialDTOs = participantDTO.getTrials();
        Trial[] trials = new Trial[0];
        if(participantDTO.getTrials() != null)
            trials = getFromDTO(trialDTOs);

        return new Participant(id, name, age, Arrays.stream(trials).toList());
    }

    public static ParticipantDTO getDTO(Participant participant){
        var id = participant.getId();
        var name = participant.getName();
        var age = participant.getAge();
        var trials = participant.getTrials();
        TrialDTO[] trialDTOs = new TrialDTO[0];
        if(participant.getTrials() != null)
            trialDTOs = getDTO(trials.toArray(new Trial[trials.size()]));
        return new ParticipantDTO(id, name, age, trialDTOs);
    }

    public static ParticipantDTO[] getDTO(Participant[] participants){
        var participantDTOS =new ParticipantDTO[participants.length];
        for(int i=0;i<participants.length;i++)
            participantDTOS[i]= getDTO(participants[i]);
        return participantDTOS;
    }

    public static Participant[] getFromDTO(ParticipantDTO[] participantDTOS){
        var participant = new Participant[participantDTOS.length];
        for(int i=0;i<participantDTOS.length;i++){
            participant[i]=getFromDTO(participantDTOS[i]);
        }
        return participant;
    }

    //

    public static Trial getFromDTO(TrialDTO trialDTO){
        var id = trialDTO.getId();
        var distance = trialDTO.getDistance();
        var style = trialDTO.getStyle();
        return new Trial(id, distance, style);
    }

    public static TrialDTO getDTO(Trial trial){
        var id = trial.getId();
        var distance = trial.getDistance();
        var style = trial.getStyle();
        return new TrialDTO(id, distance, style);
    }

    public static TrialDTO[] getDTO(Trial[] trials){
        var trialDTO=new TrialDTO[trials.length];
        for(int i=0;i<trials.length;i++)
            trialDTO[i]= getDTO(trials[i]);
        return trialDTO;
    }

    public static Trial[] getFromDTO(TrialDTO[] trialDTOS){
        var trials=new Trial[trialDTOS.length];
        for(int i=0;i<trialDTOS.length;i++){
            trials[i]=getFromDTO(trialDTOS[i]);
        }
        return trials;
    }

    public static User getFromDTO(UserDTO usdto){
        Integer id=usdto.getId();
        String username = usdto.getUsername();
        String pass=usdto.getPassword();
        return new User(id, username ,pass);

    }
    public static UserDTO getDTO(User user){
        Integer id=user.getId();
        String username = user.getUsername();
        String pass=user.getPassword();
        return new UserDTO(id,username , pass);
    }

    public static UserDTO[] getDTO(User[] users){
        UserDTO[] frDTO=new UserDTO[users.length];
        for(int i=0;i<users.length;i++)
            frDTO[i]=getDTO(users[i]);
        return frDTO;
    }

    public static User[] getFromDTO(UserDTO[] users){
        User[] friends=new User[users.length];
        for(int i=0;i<users.length;i++){
            friends[i]=getFromDTO(users[i]);
        }
        return friends;
    }
}
