using System.Data.SqlClient;
using TripApp.domain;

namespace Swim.repo
{
    public class TrailRepository : DabataseRepository<int, Trial>
    {
        public override bool Delete(int id)
        {
            string queryString = "Delete From Trial Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery() > 0;

        }

        public override IEnumerable<Trial> FindAll()
        {
            string queryString = "SELECT *  FROM  Trial";

            var command = new SqlCommand(queryString, _connection.Get());

            SqlDataReader reader = command.ExecuteReader();
            var trials = new List<Trial>();
            try
            {
                while (reader.Read())
                {
                    var id = (int)reader["id"];
                    var name = reader["name"].ToString();
                    var distance = (int)reader["distance"];
                    var style = reader["style"].ToString();
                    var startTime = (DateTime)reader["startTime"];

                    Trial trial = new()
                    {
                        Id = id,
                        Name = name,
                        Distance = distance,
                        Style = style,
                        StartTime = startTime,
                    };

                    trials.Add(trial);
                }
            }
            finally
            {
                reader.Close();
            }
            return trials;
        }

        public override Trial? FindOne(int id)
        {
            string queryString = "SELECT *  FROM  Trials where id = @id";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", id);

            Trial? trial = null;
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var distance = (int)reader["distance"];
                    var style = reader["style"].ToString();
                    var startTime = (DateTime)reader["startTime"];

                    trial = new()
                    {
                        Id = id,
                        Name = name,
                        Distance = distance,
                        Style = style,
                        StartTime = startTime
                    };
                }
            }
            finally
            {
                reader.Close();
            }
            return trial;
        }

        public override bool Save(Trial entity)
        {
            string queryString = "Insert Into Trials(name, distance, style, startTime) Values(@name, @distance, @style, @startTime)";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@distance", entity.Distance);
            command.Parameters.AddWithValue("@style", entity.Style);
            command.Parameters.AddWithValue("@startTime", entity.StartTime);

            return command.ExecuteNonQuery() > 0;
        }

        public override bool Update(Trial entity)
        {
            string queryString = "Update Users set name = @name, distance = @distance, style = @style, startTime = @startTime" +
                " Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@distance", entity.Distance);
            command.Parameters.AddWithValue("@style", entity.Style);
            command.Parameters.AddWithValue("@startTime", entity.StartTime);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
