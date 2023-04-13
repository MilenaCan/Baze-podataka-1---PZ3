using PR93_2019.Connection;
using PR93_2019.DTO.ComplexQuery1;
using PR93_2019.DTO.ComplexQuery2;
using PR93_2019.DTO.ComplexQuery3;
using PR93_2019.Model;
using PR93_2019.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DAO.Impl
{
    public class ComplexQueryDaoImplement : IComplexQueryDao
    {
        private static readonly ILicaDao lica = new LicaDaoImplement();

        public List<VrstaLicaObjekti> ObjektiPoVrstiLica()
        {
            List<VrstaLicaObjekti> vrstaLicaObjekti = new List<VrstaLicaObjekti>();
            string query = "select lice.vrstal as VrstaLica, count(objekat.ido) as BrojObjekata, sum(bilansstanja.dug) as UkupanDug from objekat " +
                " inner join lice on lice.idl = objekat.idl " +
                " inner join bilansstanja on bilansstanja.idl = objekat.idl " +
                " group by lice.vrstal";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VrstaLicaObjekti item = new VrstaLicaObjekti(reader.GetString(0), reader.GetInt32(1),
                                reader.GetDouble(2));
                            vrstaLicaObjekti.Add(item);
                        }
                    }
                }
            }

            return vrstaLicaObjekti;
        }

        public LicaObjekti SviObjektiJednogLica(string idl)
        {
            if (!lica.ExistsById(idl))
                throw new Exception("Lice sa ID: " + idl + ", ne postoji.");

            LicaObjekti licaObjekti = new LicaObjekti();
            string query = "select ido, idl, idvo, povrsina, adresa, vrednost from objekat where idl =:idl";
            List<Objekat> objekti = new List<Objekat>();

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idl", DbType.String, 50);
                    ParameterUtil.SetParameterValue(command, "idl", idl);
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Objekat objekat = new Objekat(reader.GetInt32(0), reader.GetString(1),
                                reader.GetInt32(2), reader.GetDouble(3), reader.GetString(4), reader.GetDouble(5));
                            objekti.Add(objekat);
                        }
                    }
                }
            }

            licaObjekti.Idl = idl;
            licaObjekti.objekti = objekti;
            licaObjekti.UkupnaCijena = Math.Round(objekti.Sum(x => x.Vrednost), 2);

            return licaObjekti;
        }

        public ObjektiVrsteObjekta SviObjektiVrsteObjekta(string naziv)
        {

            ObjektiVrsteObjekta objektiVrste = new ObjektiVrsteObjekta();
            string query = "select * from objekat o, vrstaobjekta vo where o.idvo = vo.idvo and nazivvo=:naziv";
            int brojObjekata = 0;
            double ukupnaCijenaObjekata = 0;
            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "naziv", DbType.String, 50);
                    ParameterUtil.SetParameterValue(command, "naziv", naziv);
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            brojObjekata++;
                            ukupnaCijenaObjekata += reader.GetDouble(5);
                            objektiVrste.ListaObjekata.Add(new Objekat(reader.GetInt32(0), reader.GetString(1),
                                reader.GetInt32(2), reader.GetDouble(3), reader.GetString(4), reader.GetDouble(5)));
                        }
                    }
                }
            }
            objektiVrste.ProsijecnaVrijednost = ukupnaCijenaObjekata / brojObjekata;
            return objektiVrste;
        }
    }
}
