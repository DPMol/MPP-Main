package swim.Domain.Models;

import swim.Domain.Utils.Entity;

import java.time.LocalDateTime;

public class Trial extends Entity<Integer> {
    String name;
    String distance;
    String style;
    LocalDateTime startTime;

    public Trial(Integer id, String name, String distance, String style, LocalDateTime startTime) {
        setId(id);
        this.name = name;
        this.distance = distance;
        this.style = style;
        this.startTime = startTime;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDistance() {
        return distance;
    }

    public void setDistance(String distance) {
        this.distance = distance;
    }

    public String getStyle() {
        return style;
    }

    public void setStyle(String style) {
        this.style = style;
    }

    public LocalDateTime getStartTime() {
        return startTime;
    }

    public void setStartTime(LocalDateTime startTime) {
        this.startTime = startTime;
    }
}
