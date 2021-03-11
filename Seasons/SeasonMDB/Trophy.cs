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
    public class Trophy
    {
        Logger.LogHandler lh = new Logger.LogHandler();

        public string GETTROFEOS(int idgnt_seasons, int idLogin, StringConect st)
        {
            String salida = null;
            var json = "";
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                MySqlCommand cmd = new MySqlCommand("GETTROFEOS", new MySqlConnection(mdb.mysqlString));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("idgnt_seasons", idgnt_seasons));
                cmd.Parameters.Add(new MySqlParameter("idLogin", idLogin));
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
                error.mensaje = "ERROR GETTROFEOS()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR GETTROFEOS() : " + json);
                salida = json;
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
