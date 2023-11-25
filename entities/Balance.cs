using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    internal class Balance
    {
        public int id { get; set; }
        public DateOnly дата { get; set; }
        public string счёт { get; set; }
        public decimal баланс { get; set; }
    }
}
