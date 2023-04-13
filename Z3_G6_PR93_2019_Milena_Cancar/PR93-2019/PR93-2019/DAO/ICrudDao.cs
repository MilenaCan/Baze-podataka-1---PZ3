using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DAO
{
    public interface ICrudDao<O, ID>
    {
        int Count();
        int Delete(O entity);
        int DeleteAll();
        int DeleteById(ID id);
        bool ExistsById(ID id);
        IEnumerable<O> FindAll();
        IEnumerable<O> FindAllById(IEnumerable<ID> ids);
        O FindById(ID id);
        int Save(O entity);
        int SaveAll(IEnumerable<O> entities);
    }
}
