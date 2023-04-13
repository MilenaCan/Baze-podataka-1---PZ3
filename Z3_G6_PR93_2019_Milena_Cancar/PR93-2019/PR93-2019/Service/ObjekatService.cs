using PR93_2019.DAO;
using PR93_2019.DAO.Impl;
using PR93_2019.DTO.ComplexQuery2;
using PR93_2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.Service
{
    public class ObjekatService
    {
        private static readonly IObjekatDao objekti = new ObjekatDaoImplement();

        public int Count()
        {
            return objekti.Count();
        }

        public void Delete(Objekat entity)
        {
            objekti.Delete(entity);
        }

        public void DeleteAll()
        {
            objekti.DeleteAll();
        }

        public void DeleteById(int id)
        {
            objekti.DeleteById(id);
        }

        public bool ExistsById(int id)
        {
            return objekti.ExistsById(id);
        }

        public IEnumerable<Objekat> FindAll()
        {
            return objekti.FindAll();
        }

        public Objekat FindById(int id)
        {
            return objekti.FindById(id);
        }
        public void Save(Objekat entity)
        {
            objekti.Save(entity);
        }

        public void SaveAll(IEnumerable<Objekat> entities)
        {
            objekti.SaveAll(entities);
        }
        public IEnumerable<ObjektiDTO> FindAllByVrstaLica( string vrstaLica)
        {
            return objekti.FindAllByVrstaLica(vrstaLica);
        }
    }
}

