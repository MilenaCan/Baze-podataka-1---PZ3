using PR93_2019.Connection;
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
    public class BilansStanjaDaoImplement : IBilansStanjaDao
    {

        public BilansStanja FindByIdLica(string id)
        {
            string query = "select idbs, idl, saldo, dug, kamata " +
                        "from bilansstanja where idl = :idl";
            BilansStanja bilansStanja = null;

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idl", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idl", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bilansStanja = new BilansStanja(reader.GetInt32(0), reader.GetString(1),
                                reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4));
                        }
                    }
                }
            }

            return bilansStanja;
        }

        public void Save(BilansStanja objekat)
        {
            string query = "update bilansstanja set " +
                "saldo=:saldo, dug=:dug, kamata=:kamata where idbs=:idbs";
            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "saldo", DbType.Double);
                    ParameterUtil.AddParameter(command, "dug", DbType.Double);
                    ParameterUtil.AddParameter(command, "kamata", DbType.Double);
                    ParameterUtil.AddParameter(command, "idbs", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "saldo", objekat.Saldo);
                    ParameterUtil.SetParameterValue(command, "dug", objekat.Dug);
                    ParameterUtil.SetParameterValue(command, "kamata", objekat.Kamata);
                    ParameterUtil.SetParameterValue(command, "idbs", objekat.Idbs);
                    command.ExecuteNonQuery();
                }
            }
            
        }
    }
}
