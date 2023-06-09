﻿using Swim.Domain.Models.TrialModels;
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
            string queryString = "Delete From Trials Where id = @id";


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
            string queryString = "SELECT *  FROM  Trials";

            var command = new SqlCommand(queryString, _connection.Get());

            SqlDataReader reader = command.ExecuteReader();
            var trials = new List<Trial>();
            try
            {
                while (reader.Read())
                {
                    var id = (int)reader["id"];
                    var distance = (int)reader["distance"];
                    var style = reader["style"].ToString();

                    Trial trial = new()
                    {
                        Id = id,
                        Distance = distance,
                        Style = style,
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

                    var distance = (int)reader["distance"];
                    var style = reader["style"].ToString();

                    trial = new()
                    {
                        Id = id,
                        Distance = distance,
                        Style = style,
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
            string queryString = "Insert Into Trials(distance, style) Values(@distance, @style)";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@distance", entity.Distance);
            command.Parameters.AddWithValue("@style", entity.Style);
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
            string queryString = "Update Users set distance = @distance, style = @style" +
                " Where id = @id";


            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@distance", entity.Distance);
            command.Parameters.AddWithValue("@style", entity.Style);

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
