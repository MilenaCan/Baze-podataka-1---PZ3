using PR93_2019.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DAO
{
    public interface IBilansStanjaDao
    {
        BilansStanja FindByIdLica(string id);
        void Save(BilansStanja objekat);
    }
}
