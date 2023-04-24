package dto;

import Models.Trial;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class ParticipantDTO implements Serializable {
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public TrialDTO[] getTrials() {
        return trials;
    }

    public void setTrials(TrialDTO[] trials) {
        this.trials = trials;
    }

    Integer id;
    String name;
    Integer age;
    TrialDTO[] trials;

    public ParticipantDTO(Integer id, String name, Integer age, TrialDTO[] trials) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.trials = trials;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Integer getAge() {
        return age;
    }

    public void setAge(Integer age) {
        this.age = age;
    }
}
