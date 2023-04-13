using PR93_2019.DAO;
using PR93_2019.DAO.Impl;
using PR93_2019.DTO.ComplexQuery1;
using PR93_2019.DTO.ComplexQuery2;
using PR93_2019.DTO.ComplexQuery3;
using PR93_2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.Service
{
    public class ComplexQueryService
    {
        private static readonly IComplexQueryDao complexQueryDao = new ComplexQueryDaoImplement();
        private static readonly ILicaDao licaDao = new LicaDaoImplement();
        private static readonly IObjekatDao objekatDao = new ObjekatDaoImplement();
        private static readonly IBilansStanjaDao bilansStanjaDao = new BilansStanjaDaoImplement();

        public ObjektiVrsteObjekta SviObjektiJedneVrste(string naziv)
        {
            return complexQueryDao.SviObjektiVrsteObjekta(naziv);
        }

        public LicaObjekti SviObjektiJednogLica(string idl)
        {
            return complexQueryDao.SviObjektiJednogLica(idl);
        }

        public List<VrstaLicaObjekti> ObjektiPoVrstiLica()
        {
            return complexQueryDao.ObjektiPoVrstiLica();
        }

        public void KupovinaObjekta(int ido, string idl)
        {
            if (!licaDao.ExistsById(idl))
                throw new Exception("Lice sa ID: " + idl + " ne postoji.");

            if (!objekatDao.ExistsById(ido))
                throw new Exception("Objekat sa ID: " + ido + " ne postoji.");

            Objekat objekat = objekatDao.FindById(ido);
            objekat.Idl = idl;
            objekatDao.Save(objekat);

            double vrijednostDin = objekat.Vrednost * 120;
            BilansStanja bilansStanja = bilansStanjaDao.FindByIdLica(idl);

            bilansStanja.Dug += vrijednostDin;
            bilansStanja.Kamata += vrijednostDin * 0.1; //10% vrijednosti objekta
            bilansStanja.Saldo -= bilansStanja.Dug + bilansStanja.Kamata;

            bilansStanjaDao.Save(bilansStanja);
        }
    }

}
