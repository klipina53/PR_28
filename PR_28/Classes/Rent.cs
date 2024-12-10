using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_28.Classes
{
    public class Rent
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime dateandtime { get; set; }
        public string fio { get; set; }
        public Rent(int id, string name, DateTime dateandtime, string fio)
        {
            this.id = id;
            this.name = name;
            this.dateandtime = dateandtime;
            this.fio = fio;
        }
    }
}
