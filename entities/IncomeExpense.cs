using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    internal class IncomeExpense
    {
        public int id { get; set; }
        public DateOnly дата { get; set; }
        public string тип { get; set; }
        public string категория { get; set; }
        public decimal сумма { get; set; }
    }
}
