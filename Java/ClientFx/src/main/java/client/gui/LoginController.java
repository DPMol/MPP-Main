package client.gui;


import Models.User;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;
import services.SwimException;
import services.IChatServices;

public class LoginController{

    private IChatServices server;
    private User crtUser;
    @FXML
    TextField user;
    @FXML
    PasswordField password;

    Parent mainChatParent;
    private ChatController chatCtrl;

    public void setServer(IChatServices s){
        server=s;
    }



    public void setParent(Parent p){
        mainChatParent=p;
    }

    public void pressLogin(ActionEvent actionEvent) {
        //Parent root;
        String username = user.getText();
        String password = this.password.getText();
        crtUser = new User(username, password);


        try{
            var user = server.login(crtUser, chatCtrl);
           // Util.writeLog("User succesfully logged in "+crtUser.getId());
            Stage stage=new Stage();
            stage.setTitle("Chat Window for " +crtUser.getId());
            stage.setScene(new Scene(mainChatParent));

            stage.setOnCloseRequest(new EventHandler<WindowEvent>() {
                @Override
                public void handle(WindowEvent event) {
                    chatCtrl.logout();
                    System.exit(0);
                }
            });

            chatCtrl.setUser(user);
            chatCtrl.setTrials();
            stage.show();
            ((Node)(actionEvent.getSource())).getScene().getWindow().hide();

        }   catch (SwimException e) {
                Alert alert = new Alert(Alert.AlertType.INFORMATION);
                alert.setTitle("MPP chat");
                alert.setHeaderText("Authentication failure");
                alert.setContentText("Wrong username or password");
                alert.showAndWait();
            }


    }

    public void pressCancel(ActionEvent actionEvent) {
        System.exit(0);
    }

    public void setUser(User user) {
        this.crtUser = user;
    }

    public void setChatController(ChatController chatController) {
        this.chatCtrl = chatController;
    }


}
