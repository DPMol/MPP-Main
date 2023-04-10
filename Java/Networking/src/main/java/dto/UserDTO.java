package dto;

import java.io.Serializable;


public class UserDTO implements Serializable{
    private Integer id;
    private String username;
    private String password;

    public UserDTO(Integer id) {
        this(id,"", "");
    }

    public UserDTO(Integer id, String username, String password) {
        this.id = id;
        this.username = username;
        this.password = password;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getPassword() {
        return password;
    }

    @Override
    public String toString(){
        return "UserDTO["+id+' '+  username+' '+ password +"]";
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
