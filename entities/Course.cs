using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int duration { get; set; }
        public int lvl { get; set; }
        public int price { get; set; }
        public int language_id { get; set; }
    }
}
