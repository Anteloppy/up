using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    internal class Account
    {
        public int id { get; set; }
        public decimal баланс { get; set; }
        public string владелец { get; set; }
    }
}
