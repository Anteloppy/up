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
        public string клиент { get; set; }
        public string курс { get; set; }
        public int стоимость { get; set; }
        public DateOnly дата_оплаты { get; set; }
    }
}
