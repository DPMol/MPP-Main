package swim;

import Models.User;

public interface IChatServices {
    void login(User user, IChatObserver client) throws ChatException;
    void logout(User user, IChatObserver client) throws ChatException;
}
