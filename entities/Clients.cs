using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    class Clients
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string contact { get; set; }
        public DateTime birth_date { get; set; }
        public int experience_id { get; set; }
        public string requirement { get; set; }
    }
}
