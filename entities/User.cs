using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    internal class User
    {
        public int id { get; set; }
        public string имя { get; set; }
        public string фамилия { get; set; }
        public string ник { get; set; }
        public string пароль { get; set; }
        public string роль { get; set; }
    }
}
