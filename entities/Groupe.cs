using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    class Groupe
    {
        public int id { get; set; }
        public int course_id { get; set; }
        public int client_id { get; set; }
        public int teacher_id { get; set; }
        public int point_quantity { get; set; }
        public int load_point { get; set; }
        public int schedule_id { get; set; }
        public int attendance_id { get; set; }
    }
}
