using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS_service.Model
{
    public class Sim_card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Base_count { get; set; }
        public string Node { get; set; }
        public int Dostup { get; set; }
    }
}
