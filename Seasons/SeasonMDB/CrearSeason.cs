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
    public class CrearSeason
    {

        Logger.LogHandler lh = new Logger.LogHandler();

        public string CRUD_gnt_seasons(CRUD_gnt_seasons crud, StringConect st)
        {
            String salida = null;
            var json = "";
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                MySqlCommand cmd = new MySqlCommand("CRUD_gnt_seasons", new MySqlConnection(mdb.mysqlString));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("idgnt_seasons", crud.idgnt_seasons));
                cmd.Parameters.Add(new MySqlParameter("nombre", crud.nombre));
                cmd.Parameters.Add(new MySqlParameter("descripcion", crud.descripcion));
                cmd.Parameters.Add(new MySqlParameter("groupMT5", crud.groupMT5));
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
                error.mensaje = "ERROR CRUD_gnt_seasons()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR CRUD_gnt_seasons() : " + json);
                salida = json;
            }
            return salida;
        }

        public string SELECT_gnt_seasons(StringConect st)
        {
            String salida = null;
            var json = "";
            try
            {
                ConectMDB mdb = new ConectMDB(st);
                MySqlConnection connect = new MySqlConnection(mdb.mysqlString);
                MySqlCommand cmd = new MySqlCommand("SELECT_gnt_seasons", new MySqlConnection(mdb.mysqlString));
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
                error.mensaje = "ERROR SELECT_gnt_seasons()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR SELECT_gnt_seasons() : " + json);
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
