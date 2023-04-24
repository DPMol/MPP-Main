package Models;

import Utils.Entity;

import java.util.List;

public class Participant extends Entity<Integer> {
    String name;
    Integer age;
    List<Trial> trials;

    public List<Trial> getTrials() {
        return trials;
    }

    public void setTrials(List<Trial> trials) {
        this.trials = trials;
    }

    public Participant(Integer id, String name, Integer age, List<Trial> trials) {
        setId(id);
        this.name = name;
        this.age = age;
        this.trials = trials;
    }

    public Participant(Integer id, String name, Integer age) {
        setId(id);
        this.name = name;
        this.age = age;
    }

    public Participant(String name, Integer age, List<Trial> trials) {
        this.trials = trials;
        this.name = name;
        this.age = age;
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
