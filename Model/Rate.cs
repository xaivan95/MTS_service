using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS_service.Model
{
    public class Rate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Actual { get; set; }
        public int Base_count { get; set; }
        public string Node { get; set; }
        public int Rate_category { get; set;}
    }
}
