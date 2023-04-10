package dto;

import Models.User;

public class DTOUtils {
    public static User getFromDTO(UserDTO usdto){
        Integer id=usdto.getId();
        String username = usdto.getUsername();
        String pass=usdto.getPassword();
        return new User(id, username ,pass);

    }
    public static UserDTO getDTO(User user){
        Integer id=user.getId();
        String username = user.getUsername();
        String pass=user.getPassword();
        return new UserDTO(id,username , pass);
    }

    public static UserDTO[] getDTO(User[] users){
        UserDTO[] frDTO=new UserDTO[users.length];
        for(int i=0;i<users.length;i++)
            frDTO[i]=getDTO(users[i]);
        return frDTO;
    }

    public static User[] getFromDTO(UserDTO[] users){
        User[] friends=new User[users.length];
        for(int i=0;i<users.length;i++){
            friends[i]=getFromDTO(users[i]);
        }
        return friends;
    }
}
