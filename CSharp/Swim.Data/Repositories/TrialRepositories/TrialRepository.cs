using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;
using System.Data.Common;
using System.Data.SqlClient;

namespace Swim.Data.Repositories.TrialRepositories
{
    public class TrialRepository : DatabaseRepository, ITrialRepository
    {
        public  bool Delete(int id)
        {
            _logger.InfoFormat("Deleting Trial: {0}", id);
            string queryString = "Delete From Trial Where id = @id";


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

        public  IEnumerable<Trial> FindAll()
        {
            _logger.Info("Searching all trials");
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

            _logger.InfoFormat("Search Finished With {0} results", trials.Count);
            return trials;
        }

        public Trial? FindOne(int id)
        {
            _logger.InfoFormat("Searching Trial: {0}", id);
            string queryString = "SELECT *  FROM  Trials where id = @id";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", id);

            Trial? trial = null;
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    _logger.Info("Trial Found");

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
                else
                {
                    _logger.Warn("Trial Not Found");
                }
            }
            finally
            {
                reader.Close();
            }

            _logger.Info("Search finished");
            return trial;
        }

        public bool Save(Trial entity)
        {
            _logger.InfoFormat("Saving Trial: {0}", entity.Id);
            string queryString = "Insert Into Trials(name, distance, style, startTime) Values(@name, @distance, @style, @startTime)";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@distance", entity.Distance);
            command.Parameters.AddWithValue("@style", entity.Style);
            command.Parameters.AddWithValue("@startTime", entity.StartTime);

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

        public bool Update(Trial entity)
        {
            _logger.InfoFormat("Updating Trial: {0}", entity.Id);
            string queryString = "Update Users set name = @name, distance = @distance, style = @style, startTime = @startTime" +
                " Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@distance", entity.Distance);
            command.Parameters.AddWithValue("@style", entity.Style);
            command.Parameters.AddWithValue("@startTime", entity.StartTime);

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
