using PR93_2019.DTO.ComplexQuery2;
using PR93_2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PR93_2019.DAO
{
    public interface IObjekatDao : ICrudDao<Objekat, int>
    {
        IEnumerable<ObjektiDTO> FindAllByVrstaLica(string vrstaLica);
    }
}
