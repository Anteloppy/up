using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    internal class Crop
    {
        public int ID { get; set; }
        public string CropName { get; set; }
        public float Area { get; set; }
        public string PlantingDate { get; set; } //Date
        public string ExpectedHarvestDate { get; set; } //Date
        public string PlantID { get; set; } //f id
    }
}
