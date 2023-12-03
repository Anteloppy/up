using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    internal class FarmingActivity
    {
        public int ID { get; set; }
        public string ActivityName { get; set; }
        public string StartDate { get; set; } //Date
        public string EndDate { get; set; } //Date
        public string Description { get; set; }
    }
}
