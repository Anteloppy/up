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
        public string название { get; set; }
        public int длительность { get; set; }
        public int уровень { get; set; }
        public int цена { get; set; }
        public string язык { get; set; }
    }
}
