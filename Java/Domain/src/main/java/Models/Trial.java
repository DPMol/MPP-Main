package Models;

import Utils.Entity;

public class Trial extends Entity<Integer> {
    Integer distance;
    String style;

    public Trial(Integer id, Integer distance, String style) {
        setId(id);
        this.distance = distance;
        this.style = style;
    }

    public Integer getDistance() {
        return distance;
    }

    public void setDistance(Integer distance) {
        this.distance = distance;
    }

    public String getStyle() {
        return style;
    }

    public void setStyle(String style) {
        this.style = style;
    }
}
