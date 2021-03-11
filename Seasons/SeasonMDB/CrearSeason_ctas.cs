using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Seasons.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.SeasonMDB
{
    public class CrearSeason_ctas
    {
        Logger.LogHandler lh = new Logger.LogHandler();

        public string CRUD_gnt_clientes_season_ctas(CRUD_gnt_clientes_season_ctas crud, StringConect st)
        {
            String salida = null;
            var json = "";
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                MySqlCommand cmd = new MySqlCommand("CRUD_gnt_clientes_season_ctas", new MySqlConnection(mdb.mysqlString));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("idgnt_clientes_season_ctas", crud.idgnt_clientes_season_ctas));
                cmd.Parameters.Add(new MySqlParameter("idgnt_seasons", crud.idgnt_seasons));
                cmd.Parameters.Add(new MySqlParameter("idgnt_clientesInfo", crud.idgnt_clientesInfo));
                cmd.Parameters.Add(new MySqlParameter("cuentasMeta", crud.cuentasMeta));
                cmd.Parameters.Add(new MySqlParameter("leverage", crud.leverage));
                cmd.Parameters.Add(new MySqlParameter("balance", crud.balance));
                cmd.Parameters.Add(new MySqlParameter("operacion", crud.operacion));
                cmd.Connection.Open();
                MySqlDataReader mdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                cmd.Connection = mdb.conn;
                salida = setJSON(mdr);
                mdr.Close();
                connect.Close();
            }
            catch (Exception e)
            {
                lh = new Logger.LogHandler();
                ErrorHandler error = new ErrorHandler();
                error.error = e.ToString();
                error.code = "600";
                error.mensaje = "ERROR CRUD_gnt_clientes_season_ctas()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR CRUD_gnt_clientes_season_ctas() : " + json);
                salida = json;
            }
            return salida;
        }

        public string SELECT_gnt_clientes_season_ctas(StringConect st)
        {
            String salida = null;
            var json = "";
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                MySqlCommand cmd = new MySqlCommand("SELECT_gnt_clientes_season_ctas", new MySqlConnection(mdb.mysqlString));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();
                MySqlDataReader mdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                cmd.Connection = mdb.conn;
                salida = setJSON(mdr);
                mdr.Close();
                connect.Close();
            }
            catch (Exception e)
            {
                lh = new Logger.LogHandler();
                ErrorHandler error = new ErrorHandler();
                error.error = e.ToString();
                error.code = "600";
                error.mensaje = "ERROR SELECT_gnt_clientes_season_ctas()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR SELECT_gnt_clientes_season_ctas() : " + json);
                salida = json;
            }
            return salida;
        }

        public string VALIDATE_SEASON(VALIDATE_SEASON val, StringConect st)
        {
            String salida = null;
            var json = "";
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                MySqlCommand cmd = new MySqlCommand("VALIDATE_SEASON", new MySqlConnection(mdb.mysqlString));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("idgnt_clientesInfo", val.idgnt_clientesInfo));
                cmd.Parameters.Add(new MySqlParameter("idgnt_seasons", val.idgnt_seasons));
                cmd.Connection.Open();
                MySqlDataReader mdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                cmd.Connection = mdb.conn;
                salida = setJSON(mdr);
                mdr.Close();
                connect.Close();
            }
            catch (Exception e)
            {
                lh = new Logger.LogHandler();
                ErrorHandler error = new ErrorHandler();
                error.error = e.ToString();
                error.code = "600";
                error.mensaje = "ERROR VALIDATE_SEASON()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR VALIDATE_SEASON() : " + json);
                salida = json;
            }
            return salida;
        }

        public string getPassword(StringConect st)
        {
            String salida = null;
            var json = "";
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                MySqlCommand cmd = new MySqlCommand("getPassword", new MySqlConnection(mdb.mysqlString));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();
                MySqlDataReader mdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                cmd.Connection = mdb.conn;
                while (mdr.Read())
                {
                    salida = mdr["mensaje"].ToString();
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
                error.mensaje = "ERROR getPassword()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR getPassword() : " + json);
                json = JsonConvert.SerializeObject(error);
            }
            return salida;
        }

        public string GETDATALIVE(int idgnt_clientesInfo, StringConect st)
        {
            String salida = null;
            var json = "";
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                MySqlCommand cmd = new MySqlCommand("GETDATALIVE", new MySqlConnection(mdb.mysqlString));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("idgnt_clientesInfo", idgnt_clientesInfo));
                cmd.Connection.Open();
                MySqlDataReader mdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                cmd.Connection = mdb.conn;
                salida = setJSON(mdr);
                mdr.Close();
                connect.Close();
            }
            catch (Exception e)
            {
                lh = new Logger.LogHandler();
                ErrorHandler error = new ErrorHandler();
                error.error = e.ToString();
                error.code = "600";
                error.mensaje = "ERROR getPassword()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR getPassword() : " + json);
                json = JsonConvert.SerializeObject(error);
            }
            return salida;
        }

        public string CRUD_gnt_cuentastrade(string pass, int idLogin, int idgnt_clientesInfo, StringConect st)
        {
            String salida = null;
            var json = "";
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                MySqlCommand cmd = new MySqlCommand("CRUD_gnt_cuentastrade", new MySqlConnection(mdb.mysqlString));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("idgnt_cuentasTrade", 0));                
                cmd.Parameters.Add(new MySqlParameter("gnt_clientesInfo_idgnt_clientesInfo", idgnt_clientesInfo));
                cmd.Parameters.Add(new MySqlParameter("gnt_catTipoCuentas_idgnt_catTipoCuentas", 0));
                cmd.Parameters.Add(new MySqlParameter("cuentasMeta", idLogin));
                cmd.Parameters.Add(new MySqlParameter("password", pass));
                cmd.Parameters.Add(new MySqlParameter("saldoBalance", 0));
                cmd.Parameters.Add(new MySqlParameter("operacion", "UP"));
                cmd.Connection.Open();
                MySqlDataReader mdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                cmd.Connection = mdb.conn;
                salida = setJSON(mdr);
                mdr.Close();
                connect.Close();
            }
            catch (Exception e)
            {
                lh = new Logger.LogHandler();
                ErrorHandler error = new ErrorHandler();
                error.error = e.ToString();
                error.code = "600";
                error.mensaje = "ERROR CRUD_gnt_cuentastrade()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR CRUD_gnt_cuentastrade() : " + json);
                json = JsonConvert.SerializeObject(error);
            }
            return salida;
        }

        public string setJSON(MySqlDataReader mdr)
        {
            string JSONString = string.Empty;
            var dataTable = new DataTable();
            dataTable.Load(mdr);
            JSONString = JsonConvert.SerializeObject(dataTable);
            return JSONString;
        }
    }
}
