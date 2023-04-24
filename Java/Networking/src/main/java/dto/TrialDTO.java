package dto;

import java.io.Serializable;

public class TrialDTO implements Serializable {
    private Integer id;
    Integer distance;
    String style;

    public TrialDTO(Integer id, Integer distance, String style) {
        this.id = id;
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

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Override
    public String toString(){
        return "TrialDTO["+id+' '+  distance+' '+ style +"]";
    }
}
