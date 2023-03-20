using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApp.domain
{
    public class Trial : Entity<int>
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }
        public DateTime StartTime { get; set; }
    }
}
