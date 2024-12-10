using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_28.Classes
{
    public class Club
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string time_start { get; set; }
        public string time_end { get; set; }
        public Club(int id, string name, string address, string time_start, string time_end)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.time_start = time_start;
            this.time_end = time_end;
        }
    }
}
