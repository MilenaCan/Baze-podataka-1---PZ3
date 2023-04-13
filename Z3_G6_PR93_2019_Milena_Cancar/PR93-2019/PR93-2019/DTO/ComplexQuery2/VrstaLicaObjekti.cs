using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DTO.ComplexQuery2
{
    public class VrstaLicaObjekti
    {
        public string VrstaLica { get; set; }
        public int BrojObjekata { get; set; }
        public double UkupanDug { get; set; }

        public VrstaLicaObjekti() { }

        public VrstaLicaObjekti(string vl, int bo, double ud)
        {
            this.VrstaLica = vl;
            this.BrojObjekata = bo;
            this.UkupanDug = ud;
        }
    }
}
