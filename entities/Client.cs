using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up.entities
{
    class Client
    {
        public int id { get; set; }
        public string имя { get; set; }
        public string фамилия { get; set; }
        public string контакты { get; set; }
        public DateOnly дата_рождения { get; set; }
        public int опыт { get; set; }
        public string потребности { get; set; }
    }
}
