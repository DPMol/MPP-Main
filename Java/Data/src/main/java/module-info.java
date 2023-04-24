module Java.Data.main {
    requires Java.Domain.main;
    requires java.sql;
    requires org.apache.logging.log4j;
    exports Repositories.UserRepositories;
    exports Repositories.ParticipantRepositories;
    exports Repositories.TrialRepositories;
    exports Repositories.RegistrationRepositories;
}