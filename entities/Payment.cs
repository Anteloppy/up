using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    class Payment
    {
        public int id { get; set; }
        public int client_id { get; set; }
        public int course_id { get; set; }
        public int cost { get; set; }
        public DateTime pay_date { get; set; }
    }
}
