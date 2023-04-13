using PR93_2019.Connection;
using PR93_2019.DTO.ComplexQuery1;
using PR93_2019.Model;
using PR93_2019.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DAO.Impl
{
    public class LicaDaoImplement : ILicaDao
    {
        public bool ExistsById(string id)
        {
            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(string id, IDbConnection connection)
        {
            string query = "select * from lice where idl=:idl";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "idl", DbType.String);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idl", id);
                return command.ExecuteScalar() != null;
            }
        }

        
    }
}
