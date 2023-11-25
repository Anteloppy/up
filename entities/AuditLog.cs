using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    internal class AuditLog
    {
        public int id { get; set; }
        public DateTime дата_время { get; set; }
        public string пользователь { get; set; }
        public string действие { get; set; }
        public string описание { get; set; }
    }
}
