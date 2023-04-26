using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS_service.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Birthday { get; set; }
        public string Doc_number { get; set; }
        public string Doc_date { get; set; }
        public string? Adres { get; set; }
    }
}
