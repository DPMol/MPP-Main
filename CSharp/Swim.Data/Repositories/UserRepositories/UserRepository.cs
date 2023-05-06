using log4net;
using log4net.Core;
using Swim.Domain.Models.UserModels;
using System.Data.SqlClient;

namespace Swim.Data.Repositories.UserRepositories
{
    public class UserRepository : DatabaseRepository, IUserRepository
    {
        public bool Delete(int id)
        {
            _logger.InfoFormat("Deleting User: {0}", id);
            string queryString = "Delete From Users Where id = @id";


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

        public IEnumerable<User> FindAll()
        {
            _logger.Info("Searching all users");
            string queryString = "SELECT *  FROM  Users";

            var command = new SqlCommand(queryString, _connection.Get());

            SqlDataReader reader = command.ExecuteReader();
            var users = new List<User>();
            try
            {
                while (reader.Read())
                {
                    var id = (int)reader["id"];
                    var username = reader["username"].ToString();
                    var password = reader["password"].ToString();

                    User user = new()
                    {
                        Id = id,
                        Username = username,
                        Password = password
                    };

                    users.Add(user);
                }
            }
            finally
            {
                reader.Close();
            }

            _logger.InfoFormat("Search Finished With {0} results", users.Count);
            return users;
        }

        public User? FindBy(string username, string password)
        {
            _logger.Info("Searching user");
            string queryString = "SELECT *  FROM  Users Where username = @username and password = @password";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            SqlDataReader reader = command.ExecuteReader();
            User? user = null;
            try
            {
                if (reader.Read())
                {
                    _logger.Info("User Found");

                    var id = (int)reader["id"];
                    var dbUsername = reader["username"].ToString();
                    var dbPassword = reader["password"].ToString();

                    user = new()
                    {
                        Id = id,
                        Username = dbUsername,
                        Password = dbPassword
                    };
                }
                else
                {
                    _logger.Warn("User Not Found");
                }
            }
            finally
            {
                reader.Close();
            }

            _logger.InfoFormat("Search Finished");
            return user;
        }

        public User? FindOne(int id)
        {
            _logger.InfoFormat("Searching User: {0}", id);
            string queryString = "SELECT *  FROM  Users where id = @id";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            User? user = null;
            try
            {
                if (reader.Read())
                {
                    _logger.Info("User Found");

                    var username = reader["username"].ToString();
                    var password = reader["password"].ToString();

                    user = new()
                    {
                        Id = id,
                        Username = username,
                        Password = password
                    };                    
                }
                else
                {
                    _logger.Warn("User Not Found");
                }
            }
            finally
            {
                reader.Close();
            }

            _logger.Info("Search finished");
            return user;
        }

        public bool Save(User entity)
        {
            _logger.InfoFormat("Saving User: {0}", entity.Id);
            string queryString = "Insert Into Users(username, password) Values(@username, @password)";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@username", entity.Username);
            command.Parameters.AddWithValue("@password", entity.Password);

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

        public bool Update(User entity)
        {
            _logger.InfoFormat("Updating User: {0}", entity.Id);
            string queryString = "Update Users set username = @username, password = @password Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@username", entity.Username);
            command.Parameters.AddWithValue("@password", entity.Password);
            command.Parameters.AddWithValue("@id", entity.Id);

            var result = command.ExecuteNonQuery() > 0;

            if (result)
            {
                _logger.Info("Update Successful");
            }
            else
            {
                _logger.Warn("Update failed");
            }

            return result;
        }
    }
}
