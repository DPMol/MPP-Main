using System.Data.SqlClient;
using TripApp.domain;

namespace Swim.repo
{
    internal class UserRepository : DabataseRepository<int, User>
    {
        public override bool Delete(int id)
        {
            string queryString = "Delete From Users Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery() > 0;

        }

        public override IEnumerable<User> FindAll()
        {
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
                        Username= username,
                        Password= password
                    };

                    users.Add(user);
                }
            }
            finally
            {
                reader.Close();
            }
            return users;
        }

        public override User? FindOne(int id)
        {
            string queryString = "SELECT *  FROM  Users where id = @id";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            User? user = null;
            try
            {
                if (reader.Read())
                {
                    var username = reader["username"].ToString();
                    var password = reader["password"].ToString();

                    user = new()
                    {
                        Id = id,
                        Username = username,
                        Password = password
                    };
                }
            }
            finally
            {
                reader.Close();
            }
            return user;
        }

        public override bool Save(User entity)
        {
            string queryString = "Insert Into Users(username, password) Values(@username, @password)";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@username", entity.Username);
            command.Parameters.AddWithValue("@password", entity.Password);

            return command.ExecuteNonQuery() > 0;
        }

        public override bool Update(User entity)
        {
            string queryString = "Update Users set username = @username, password = @password Where id = @id";
            

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@username", entity.Username);
            command.Parameters.AddWithValue("@password", entity.Password);
            command.Parameters.AddWithValue("@id", entity.Id);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
