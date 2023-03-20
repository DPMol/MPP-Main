package com.example.applicationsemester.domain;

public class User extends Entity<Integer>{
    String username;
    String password;

    public User(Integer userID, String username, String password) {
        setId(userID);
        this.username = username;
        this.password = password;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
