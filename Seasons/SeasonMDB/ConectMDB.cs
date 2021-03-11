using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Seasons.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.SeasonMDB
{
    public class ConectMDB
    {
        /*Clase para poder conectarte a la base de datos deseada, regresa una varibale de tipo MySqlConnection,
         con ella podras realizar las transacciones deseadas*/
        public MySqlConnection conn;
        public String mysqlString;
        Logger.LogHandler lh = new Logger.LogHandler();

        public ConectMDB(StringConect sc)
        {
            var json = "";
            mysqlString = "Server=" + sc.server + ";uid=" + sc.uid + ";pwd=" + sc.pwd + ";database=" + sc.database + ";SslMode=none;Max Pool Size=50000;Pooling=True;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = mysqlString;
                conn.Open();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                lh = new Logger.LogHandler();
                ErrorHandler error = new ErrorHandler();
                error.error = ex.ToString();
                error.code = "600";
                error.mensaje = "ERROR ConectMDB()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR ConectMDB() : " + json);
            }
        }
    }
}
