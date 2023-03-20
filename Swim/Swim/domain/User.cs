using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApp.domain
{
    public class User : Entity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
