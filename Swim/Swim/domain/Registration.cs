using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApp.domain
{
    public class Registration : Entity<int>
    {
        public User User { get; set; }
        public Trial Trial { get; set; }
    }
}
