package Models;

import Utils.Entity;

public class Trial extends Entity<Integer> {
    String distance;
    String style;

    public Trial(Integer id, String distance, String style) {
        setId(id);
        this.distance = distance;
        this.style = style;
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
}
