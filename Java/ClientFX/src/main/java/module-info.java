module Java.ClientFx.main {
    requires javafx.controls;
    requires javafx.graphics;
    requires javafx.fxml;
    requires Java.Services.main;
    requires Java.Networking.main;
    requires Java.Domain.main;
    requires org.apache.logging.log4j;

    opens client;
    opens client.gui;
    exports client;
}