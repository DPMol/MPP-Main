package com.example.applicationsemester.domain;

public class Registration extends Entity<Integer>{
    Integer UserId;
    Integer ProbaId;

    public Registration(Integer id, Integer userId, Integer probaId) {
        setId(id);
        UserId = userId;
        ProbaId = probaId;
    }

    public Integer getUserId() {
        return UserId;
    }

    public void setUserId(Integer userId) {
        UserId = userId;
    }

    public Integer getProbaId() {
        return ProbaId;
    }

    public void setProbaId(Integer probaId) {
        ProbaId = probaId;
    }
}
