using Swim.Domain.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.Networking
{
    internal class DTOUtils
    {
        internal static UserDTO getDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
            };
        }

        internal static User getFromDTO(UserDTO udto)
        {
            return new User
            {
                Id = udto.Id,
                Username = udto.Username,
                Password = udto.Password,
            };
        }
    }
}
