using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    internal class FinancialTransaction
    {
        public int id { get; set; }
        public DateOnly дата { get; set; }
        public string тип { get; set; }
        public decimal сумма { get; set; }
        public string отправитель { get; set; }
        public string получатель { get; set; }
    }
}
