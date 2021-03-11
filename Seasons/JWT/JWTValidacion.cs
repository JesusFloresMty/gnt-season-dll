using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Seasons.Modelos;
using Seasons.SeasonMDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.JWT
{
    public class JWTValidacion
    {
        Logger.LogHandler lh = new Logger.LogHandler();

        public string validacionMDB(JWTModel mod, StringConect st)
        {
            String salida = null;
            var json = "";
            MySqlCommand cmd = null;
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                switch (mod.tipo)
                {
                    case "INFO":
                        cmd = new MySqlCommand("JWTVALIDACION", new MySqlConnection(mdb.mysqlString));
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("hashCode", mod.hashCode));
                        cmd.Parameters.Add(new MySqlParameter("idgnt_clientesInfo", mod.idgnt_clientesInfo));
                        break;
                    case "EMAIL":
                        cmd = new MySqlCommand("JWTVALIDACIONEMAIL", new MySqlConnection(mdb.mysqlString));
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("hashCode", mod.hashCode));
                        cmd.Parameters.Add(new MySqlParameter("email", mod.email));
                        break;
                    case "IBS":
                        cmd = new MySqlCommand("JWTVALIDACIONIBS", new MySqlConnection(mdb.mysqlString));
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("idIB", mod.idIB));
                        cmd.Parameters.Add(new MySqlParameter("idSIB", mod.idSIB));
                        cmd.Parameters.Add(new MySqlParameter("hashcode", mod.hashCode));
                        break;
                    case "OPERACION":
                        cmd = new MySqlCommand("JWTVALIDACIONOP", new MySqlConnection(mdb.mysqlString));
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("cuentasMeta", mod.cuentasMeta));
                        cmd.Parameters.Add(new MySqlParameter("hashcode", mod.hashCode));
                        break;
                    case "SEASON":
                        cmd = new MySqlCommand("JWTVALIDACIONSEASON", new MySqlConnection(mdb.mysqlString));
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("cuentasMeta", mod.cuentasMeta));
                        cmd.Parameters.Add(new MySqlParameter("hashcode", mod.hashCode));
                        break;
                }
                cmd.Connection.Open();
                MySqlDataReader mdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                cmd.Connection = mdb.conn;
                while (mdr.Read())
                {
                    salida = mdr["mensaje"].ToString().Trim();
                }
                mdr.Close();
                connect.Close();
            }
            catch (Exception e)
            {
                lh = new Logger.LogHandler();
                ErrorHandler error = new ErrorHandler();
                error.error = e.ToString();
                error.code = "600";
                error.mensaje = "ERROR validacionMDB()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR validacionMDB() : " + json);
                salida = json;
            }
            return salida;
        }
    }
}
