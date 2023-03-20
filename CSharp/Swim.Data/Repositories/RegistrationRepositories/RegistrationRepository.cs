using Swim.Domain.Models.Registration;
using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;
using System.Data.SqlClient;

namespace Swim.Data.Repositories.RegistrationRepositories
{
    public class RegistrationRepository : DatabaseRepository, IRegistrationRepository
    {
        public bool Delete(int id)
        {
            _logger.InfoFormat("Deleting Registration: {0}", id);
            string queryString = "Delete From Registration Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", id);

            var result = command.ExecuteNonQuery() > 0;

            if (result)
            {
                _logger.Info("Delete Successful");
            }
            else
            {
                _logger.Warn("Delete Failed");
            }

            return result;

        }

        public IEnumerable<Registration> FindAll()
        {
            _logger.Info("Searching all registrations");
            string queryString = "SELECT Trials.id, Users.id as userId, Users.username, Users.password, " +
                "Trials.id as trialId, Trials.name, Trials.distance, Trials.style, Trials.startTime" +
                "FROM Registrations " +
                "Inner Join Users on Registrations.userId = Users.id " +
                "Inner Join Trials on Registrations.trialId = Trials.id";

            var command = new SqlCommand(queryString, _connection.Get());

            SqlDataReader reader = command.ExecuteReader();
            var registrations = new List<Registration>();
            try
            {
                while (reader.Read())
                {
                    var id = (int)reader["id"];
                    var userId = (int)reader["userId"];
                    var username = reader["username"].ToString();
                    var password = reader["password"].ToString();
                    var trialId = (int)reader["trialId"];
                    var name = reader["name"].ToString();
                    var distance = (int)reader["distance"];
                    var style = reader["style"].ToString();
                    var startTime = (DateTime)reader["startTime"];

                    var user = new User()
                    {
                        Id = userId,
                        Username = username,
                        Password = password
                    };
                    var trial = new Trial()
                    {
                        Id = trialId,
                        Name = name,
                        Distance = distance,
                        Style = style,
                        StartTime = startTime,
                    };
                    var registration = new Registration()
                    {
                        Id = id,
                        User = user,
                        Trial = trial
                    };

                    registrations.Add(registration);
                }
            }
            finally
            {
                reader.Close();
            }

            _logger.InfoFormat("Search Finished With {0} results", registrations.Count);
            return registrations;
        }

        public Registration? FindOne(int id)
        {
            _logger.InfoFormat("Searching Registration: {0}", id);
            string queryString = "SELECT Trials.id, Users.id as userId, Users.username, Users.password, " +
                "Trials.id as trialId, Trials.name, Trials.distance, Trials.style, Trials.startTime" +
                "FROM Registrations " +
            "Inner Join Users on Registrations.userId = Users.id " +
                "Inner Join Trials on Registrations.trialId = Trials.id " +
                "Where id = @id";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", id);

            Registration? registration = null;
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    _logger.Info("Registration Found");

                    var userId = (int)reader["userId"];
                    var username = reader["username"].ToString();
                    var password = reader["password"].ToString();
                    var trialId = (int)reader["trialId"];
                    var name = reader["name"].ToString();
                    var distance = (int)reader["distance"];
                    var style = reader["style"].ToString();
                    var startTime = (DateTime)reader["startTime"];

                    var user = new User()
                    {
                        Id = userId,
                        Username = username,
                        Password = password
                    };
                    var trial = new Trial()
                    {
                        Id = trialId,
                        Name = name,
                        Distance = distance,
                        Style = style,
                        StartTime = startTime,
                    };
                    registration = new Registration()
                    {
                        Id = id,
                        User = user,
                        Trial = trial
                    };
                }
                else
                {
                    _logger.Warn("Registration Not Found");
                }
            }
            finally
            {
                reader.Close();
            }

            _logger.Info("Search finished");
            return registration;
        }

        public bool Save(Registration entity)
        {
            _logger.InfoFormat("Saving Registration: {0}", entity.Id);
            string queryString = "Insert Into Registrations(id, userId, trialId) Values(@id, @userId, @trialId)";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", entity.Id);
            command.Parameters.AddWithValue("@userId", entity.User.Id);
            command.Parameters.AddWithValue("@trialId", entity.Trial.Id); ;

            var result = command.ExecuteNonQuery() > 0;

            if (result)
            {
                _logger.Info("Save Successful");
            }
            else
            {
                _logger.Warn("Save failed");
            }

            return result;
        }

        public bool Update(Registration entity)
        {
            _logger.InfoFormat("Updating Registration: {0}", entity.Id);
            string queryString = "Update Users set userId = @userId, trialId = @trialId, style = @style" +
                " Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@userId", entity.User.Id);
            command.Parameters.AddWithValue("@trialId", entity.Trial.Id);

            var result = command.ExecuteNonQuery() > 0;

            if (result)
            {
                _logger.Info("Save Successful");
            }
            else
            {
                _logger.Warn("Save failed");
            }

            return result;
        }
    }
}
