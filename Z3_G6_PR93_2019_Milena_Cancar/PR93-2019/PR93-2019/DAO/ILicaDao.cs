using PR93_2019.DTO.ComplexQuery1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DAO
{
    public interface ILicaDao
    {
        bool ExistsById(string id);

    }
}
