using Swim.Domain.Models.ParticipantModels;
using System.Data;
using System.Data.SqlClient;

namespace Swim.Data.Repositories.ParticipantRepositories
{
    public class ParticipantRepository : DatabaseRepository, IParticipantRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Participant> FindBy(int trialId)
        {
            _logger.InfoFormat("Searching Trial");
            string queryString = "SELECT* FROM  Participants p Where" +
                " EXISTS(SELECT * FROM Registrations WHERE participantId = p.Id and trialId = @id)";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@id", trialId);

            SqlDataReader reader = command.ExecuteReader();
            try
            {
                var participants = new List<Participant>();
                while (reader.Read())
                {
                    var id = (int)reader["id"];
                    var name = reader["name"].ToString();
                    var age = (int)reader["age"];

                    participants.Add(
                        new Participant
                        {
                            Id = id,
                            Name = name,
                            Age = age
                        }
                        );
                }

                return participants;
            }
            finally
            {
                reader.Close();
            }
        }

        public Participant? FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Participant entity)
        {
            _logger.InfoFormat("Saving Participant");
            string queryString = "Insert Into Participants(name, age) OUTPUT INSERTED.ID Values(@name, @age)";

            string queryString2 = "Insert Into Registrations(participantId, trialId) Values (@pid, @tid)";

            var command = new SqlCommand(queryString, _connection.Get());
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@age", entity.Age);

            
            int insertedId = (int)command.ExecuteScalar();

            foreach(var trial in entity.Trials)
            {
                using (command = new SqlCommand(queryString2, _connection.Get()))
                {
                    command.Parameters.AddWithValue("@pid", insertedId);
                    command.Parameters.AddWithValue("@tid", trial.Id);

                    command.ExecuteNonQuery();
                }
            }

            return true;
        }

        public bool Update(Participant entity)
        {
            throw new NotImplementedException();
        }
    }
}
