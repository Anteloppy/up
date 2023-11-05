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
        public string курс { get; set; }
        public string клиент { get; set; }
        public string преподаватель { get; set; }
        public int мест { get; set; }
        public int занято { get; set; }
        public string рассписание { get; set; }
        public string посещаемость { get; set; }
    }
}
