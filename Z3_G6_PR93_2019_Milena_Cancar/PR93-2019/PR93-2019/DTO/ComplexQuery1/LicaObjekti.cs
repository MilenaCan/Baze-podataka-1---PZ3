using PR93_2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DTO.ComplexQuery1
{
    public class LicaObjekti
    {
        public string Idl { get; set; }
        public List<Objekat> objekti { get; set; }
        public double UkupnaCijena { get; set; }

    }
}
