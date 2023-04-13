using PR93_2019.Connection;
using PR93_2019.DTO.ComplexQuery2;
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
    public class ObjekatDaoImplement : IObjekatDao
    {
        public int Count()
        {
            string query = "select count(*) from objekat";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int Delete(Objekat entity)
        {
            return DeleteById(entity.Ido);
        }

        public int DeleteAll()
        {
            string query = "delete from objekat";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteById(int id)
        {
            string query = "delete from objekat where ido=:ido";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "ido", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "ido", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(int id)
        {
            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(int id, IDbConnection connection)
        {
            string query = "select * from objekat where ido=:ido";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "ido", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "ido", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<Objekat> FindAll()
        {
            string query = "select ido, idl, idvo, povrsina, adresa, vrednost from objekat";
            List<Objekat> objekti = new List<Objekat>();

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
                            Objekat objekat = new Objekat(reader.GetInt32(0), reader.GetString(1),
                                reader.GetInt32(2), reader.GetDouble(3), reader.GetString(4), reader.GetDouble(5));
                            objekti.Add(objekat);
                        }
                    }
                }
            }

            return objekti;
        }

        public IEnumerable<Objekat> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ido, idl, idvo, povrsina, adresa, vrednost from objekat where ido in (");
            foreach (int id in ids)
            {
                sb.Append(":ido" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1); 
            sb.Append(")");

            List<Objekat> objekti = new List<Objekat>();

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "id" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "id" + id, id);
                    }
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

            return objekti;
        }

        public Objekat FindById(int id)
        {
            string query = "select ido, idl, idvo, povrsina, adresa, vrednost " +
                        "from objekat where ido = :ido";
            Objekat objekat = null;

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "ido", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "ido", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            objekat = new  Objekat(reader.GetInt32(0), reader.GetString(1),
                                 reader.GetInt32(2), reader.GetDouble(3), reader.GetString(4), reader.GetDouble(5));
                        }
                    }
                }
            }

            return objekat;
        }


        public int Save(Objekat entity)
        {
            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }
        private int Save(Objekat objekat, IDbConnection connection)
        {
            
            string insertSql = "insert into objekat (idl, idvo, povrsina, adresa, vrednost, ido) " +
                "values (:idl , :idvo, :povrsina, :adresa, :vrednost, :ido)";
            string updateSql = "update objekat set idl=:idl, idvo=:idvo, " +
                "povrsina=:povrsina, adresa=:adresa, vrednost=:vrednost where ido=:ido";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(objekat.Ido, connection) ? updateSql : insertSql;
                ParameterUtil.AddParameter(command, "idl", DbType.String, 50);
                ParameterUtil.AddParameter(command, "idvo", DbType.Int32);
                ParameterUtil.AddParameter(command, "povrsina", DbType.Double);
                ParameterUtil.AddParameter(command, "adresa", DbType.String, 50);
                ParameterUtil.AddParameter(command, "vrednost", DbType.Double);
                ParameterUtil.AddParameter(command, "ido", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idl", objekat.Idl);
                ParameterUtil.SetParameterValue(command, "idvo", objekat.Idvo);
                ParameterUtil.SetParameterValue(command, "povrsina", objekat.Povrsina);
                ParameterUtil.SetParameterValue(command, "adresa", objekat.Adresa);
                ParameterUtil.SetParameterValue(command, "vrednost", objekat.Vrednost);
                ParameterUtil.SetParameterValue(command, "ido", objekat.Ido);
                return command.ExecuteNonQuery();
            }
        }


        public int SaveAll(IEnumerable<Objekat> entities)
        {
            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction(); 

                int numSaved = 0;

                
                foreach (Objekat entity in entities)
                {
                    // changes are visible only to current connection
                    numSaved += Save(entity, connection);
                }

                // transaction ends successfully, changes are now visible to other connections as well
                transaction.Commit();

                return numSaved;
            }
        }

        public IEnumerable<ObjektiDTO> FindAllByVrstaLica(string vrstaLica)
        {
            string query = "select ido, objekat.idl, vrstaobjekta.nazivvo, vrednost, lice.imel, lice.przl from objekat" +
                " inner join lice on lice.idl = objekat.idl" +
                " inner join vrstaobjekta on vrstaobjekta.idvo = objekat.idvo " +
                " where lice.vrstal = :vrstal";
            List<ObjektiDTO> objekti = new List<ObjektiDTO>();

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "vrstal", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "vrstal", vrstaLica);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ObjektiDTO objekat = new ObjektiDTO(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetDouble(3), reader.GetString(4), reader.GetString(5));
                            objekti.Add(objekat);
                        }
                    }
                }
            }

            return objekti;
        }
    }
    }

