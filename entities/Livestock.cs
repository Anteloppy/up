using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    internal class Livestock
    {
        public int ID { get; set; }
        public string AnimalType { get; set; }
        public int Quantity { get; set; }
        public DateOnly AcquisitionDate { get; set; }
    }
}
