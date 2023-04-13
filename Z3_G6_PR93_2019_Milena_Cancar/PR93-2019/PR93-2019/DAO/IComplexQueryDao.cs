using PR93_2019.DTO.ComplexQuery1;
using PR93_2019.DTO.ComplexQuery2;
using PR93_2019.DTO.ComplexQuery3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DAO
{
    public interface IComplexQueryDao
    {
        LicaObjekti SviObjektiJednogLica(string idl);
        List<VrstaLicaObjekti> ObjektiPoVrstiLica();

        ObjektiVrsteObjekta SviObjektiVrsteObjekta(string naziv);
    }
}
