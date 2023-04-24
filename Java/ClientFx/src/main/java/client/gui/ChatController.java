package client.gui;

import Models.Participant;
import Models.Trial;
import Models.User;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.SelectionMode;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;
import services.SwimException;
import services.IChatObserver;
import services.IChatServices;

import java.net.URL;
import java.util.List;
import java.util.ResourceBundle;

public class ChatController implements Initializable, IChatObserver {

    @FXML
    private TextField nameField;
    @FXML
    private TextField ageField;
    @FXML
    private TableView<Trial> trialsTable;
    @FXML
    private TableView<Trial> trialsAddTable;
    @FXML
    private TableView<Participant> participantsTable;
    @FXML
    private TableColumn<Trial, Integer> distanceColumn;
    @FXML
    private TableColumn<Trial, String> styleColumn;
    @FXML
    private TableColumn<Trial, Integer> distanceAddColumn;
    @FXML
    private TableColumn<Trial, String> styleAddColumn;
    @FXML
    private TableColumn<Participant, String> nameColumn;
    @FXML
    private TableColumn<Participant, Integer> ageColumn;

    private IChatServices server;
    private User user;

    public void setUser(User user) {
        this.user = user;
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        distanceColumn.setCellValueFactory(
                new PropertyValueFactory<>("distance")
        );
        styleColumn.setCellValueFactory(
                new PropertyValueFactory<>("style")
        );

        distanceAddColumn.setCellValueFactory(
                new PropertyValueFactory<>("distance")
        );
        styleAddColumn.setCellValueFactory(
                new PropertyValueFactory<>("style")
        );

        nameColumn.setCellValueFactory(
                new PropertyValueFactory<>("name")
        );
        ageColumn.setCellValueFactory(
                new PropertyValueFactory<>("age")
        );

        trialsAddTable.getSelectionModel().setSelectionMode(
                SelectionMode.MULTIPLE
        );
        trialsTable.getSelectionModel().selectedItemProperty().addListener((obs, oldSelection, newSelection) -> setParticipants());
    }

    public void setServer(IChatServices s){
        server=s;
    }

    @FXML
    void logout() {
        try {
            server.logout(user, this);
        } catch (SwimException e) {
            System.out.println("Logout error " + e);
        }
    }

    public void setTrials(){
        try {
            var lFr = server.getTrials();
            trialsTable.getItems().clear();
            for (var u : lFr) {
                trialsTable.getItems().add(u);
                trialsAddTable.getItems().add(u);
            }
            if(trialsTable.getItems().size()>0)
                trialsTable.getSelectionModel().select(0);

        } catch (SwimException e) {
            e.printStackTrace();
        }
    }

    public void setParticipants(){
        try {
            var trial = trialsTable.getSelectionModel().getSelectedItem();
            var participants = server.getParticipants(trial.getId());
            participantsTable.getItems().clear();
            for (var u : participants) {
                participantsTable.getItems().add(u);
            }
        } catch (SwimException e) {
            e.printStackTrace();
        }
    }

    @FXML
    public void addParticipant(){
        try {
            var name = nameField.getText();
            var age = Integer.valueOf(ageField.getText());

            List<Trial> trials= trialsAddTable.getSelectionModel().getSelectedItems();
            var participant = new Participant(name, age ,trials);
            server.addParticipant(participant);
        } catch (SwimException e) {
            System.out.println("Logout error " + e);
        }
    }
}
