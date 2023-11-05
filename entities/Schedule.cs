using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    class Schedule
    {
        public int id { get; set; }
        public DateOnly день { get; set; }
        public TimeOnly время { get; set; }
    }
}
