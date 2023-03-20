using System.Data.SqlClient;
using TripApp.domain;

namespace Swim.repo
{
    public class RegistrationRepository : DabataseRepository<int, Registration>
    {
        public override bool Delete(int id)
        {
            string queryString = "Delete From Registration Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery() > 0;

        }

        public override IEnumerable<Registration> FindAll()
        {
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
            return registrations;
        }

        public override Registration? FindOne(int id)
        {
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
                    registration = new Registration()
                    {
                        Id = id,
                        User = user,
                        Trial = trial
                    };
                }
            }
            finally
            {
                reader.Close();
            }
            return registration;
        }

        public override bool Save(Registration entity)
        {
            string queryString = "Insert Into Registrations(id, userId, trialId) Values(@id, @userId, @trialId)";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", entity.Id);
            command.Parameters.AddWithValue("@userId", entity.User.Id);
            command.Parameters.AddWithValue("@trialId", entity.Trial.Id);;

            return command.ExecuteNonQuery() > 0;
        }

        public override bool Update(Registration entity)
        {
            string queryString = "Update Users set userId = @userId, trialId = @trialId, style = @style" +
                " Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@userId", entity.User.Id);
            command.Parameters.AddWithValue("@trialId", entity.Trial.Id);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
