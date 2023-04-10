package Models;

import Utils.Entity;

public class Registration extends Entity<Integer> {
    Participant Participant;
    Trial Trial;

    public Registration(Integer id, Participant participant, Trial trial) {
        setId(id);
        this.Participant = participant;
        this.Trial = trial;
    }

    public Registration(Participant participant, Trial trial) {
        this.Participant = participant;
        this.Trial = trial;
    }

    public Participant getParticipant() {
        return Participant;
    }

    public void setParticipant(Participant participant) {
        Participant = participant;
    }

    public Trial getTrial() {
        return Trial;
    }

    public void setTrial(Trial trial) {
        Trial = trial;
    }
}
