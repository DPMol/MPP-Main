using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;

namespace Swim.Networking
{
    internal class DTOUtils
    {
        internal static UserDTO GetDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
            };
        }

        internal static User GetFromDTO(UserDTO udto)
        {
            return new User
            {
                Id = udto.Id,
                Username = udto.Username,
                Password = udto.Password,
            };
        }

        internal static Trial GetFromDTO(TrialDTO trialDTO)
        {
            return new Trial
            {
                Id = trialDTO.Id,
                Distance = trialDTO.Distance,
                Style = trialDTO.Style,
            };
        }

        internal static TrialDTO GetDTO(Trial trial)
        {
            return new TrialDTO
            {
                Distance = trial.Distance,
                Style = trial.Style,
                Id = trial.Id
            };
        }

        internal static TrialDTO[] GetDTO(Trial[] trials)
        {
            TrialDTO[] trialDTOs = new TrialDTO[trials.Length];
            for (int i = 0; i < trialDTOs.Length; i++)
            {
                trialDTOs[i] = GetDTO(trials[i]);
            }
            return trialDTOs;
        }
        internal static Trial[] GetFromDTO(TrialDTO[] trialDTOs)
        {
            Trial[] trials = new Trial[trialDTOs.Length];
            for (int i = 0; i < trials.Length; i++)
            {
                trials[i] = GetFromDTO(trialDTOs[i]);
            }
            return trials;
        }

        internal static ParticipantDTO GetDTO(Participant participant)
        {
            return new ParticipantDTO
            {
                Id = participant.Id,
                Name = participant.Name,
                Age = participant.Age,
                Trials = participant.Trials == null ? null : GetDTO(participant.Trials.ToArray())
            };
        }

        internal static Participant GetFromDTO(ParticipantDTO participantDTO)
        {
            return new Participant
            {
                Id = participantDTO.Id,
                Name = participantDTO.Name,
                Age = participantDTO.Age,
                Trials = participantDTO.Trials == null ? null : GetFromDTO(participantDTO.Trials).ToList()
            };
        }

        internal static Participant[] GetFromDTO(ParticipantDTO[] participantDTOs)
        {
            Participant[] participants = new Participant[participantDTOs.Length];
            for (int i = 0; i < participants.Length; i++)
            {
                participants[i] = GetFromDTO(participantDTOs[i]);
            }
            return participants;
        }

        internal static ParticipantDTO[] GetDTO(Participant[] participants)
        {
            ParticipantDTO[] participantDTOs = new ParticipantDTO[participants.Length];
            for (int i = 0; i < participantDTOs.Length; i++)
            {
                participantDTOs[i] = GetDTO(participants[i]);
            }
            return participantDTOs;
        }
    }
}
