using MetaQuotes.MT5WebAPI;
using MetaQuotes.MT5WebAPI.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Seasons.Metatrader;
using Seasons.Modelos;
using Seasons.SeasonMDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.MT5Ctas
{
    public class CrearCuenta
    {
        Logger.LogHandler lh = new Logger.LogHandler();
        private MT5WebAPI m_WebApi;

        public string cuentaSalida(Modelos.CrearCuenta cuenta, Conector conectorGNT, StringConect st)
        {
            string salida = null;
            var json = "";
            try
            {
                Correo co = new Correo();                
                CrearSeason_ctas mdb = new CrearSeason_ctas();
                ConectMT5 gnt = new ConectMT5();
                m_WebApi = gnt.conect(conectorGNT);
                lh.LogMessageToFile("m_WebApi : " + m_WebApi.IsConnected);
                MetaQuotes.MT5WebAPI.MTRetCode codes;
                MetaQuotes.MT5WebAPI.Common.MTUser user = new MetaQuotes.MT5WebAPI.Common.MTUser();
                MetaQuotes.MT5WebAPI.Common.MTUser userNew = new MetaQuotes.MT5WebAPI.Common.MTUser();
                user.Balance = cuenta.balance;
                user.Account = cuenta.idgnt_clientesInfo;
                user.Name = cuenta.name;
                user.Email = cuenta.email;
                user.MainPassword = cuenta.mainPassword;
                user.InvestPassword = "SeasonsGNT";
                user.Group = cuenta.group;
                user.Comment = "Cuenta Season";
                user.Leverage = cuenta.leverage;
                user.Phone = cuenta.phone;
                user.PhonePassword = "1234567890";
                user.ID = cuenta.idgnt_clientesInfo;
                user.Rights = MTUser.EnUsersRights.USER_RIGHT_TRADE_DISABLED;
                MTUser.CreateDefault();
                codes = m_WebApi.UserAdd(user, out userNew);
                lh.LogMessageToFile("codes : " + codes.ToString());
                lh.LogMessageToFile("user.MainPassword : " + user.MainPassword);
                codes = m_WebApi.UserDepositChange(userNew.Login, cuenta.balance, cuenta.depositText, MTDeal.EnDealAction.DEAL_BALANCE);
                userNew.MainPassword = cuenta.mainPassword;
                userNew.Group = cuenta.group;
                userNew.Balance = cuenta.balance;
                userNew.Leverage = cuenta.leverage;
                json = JsonConvert.SerializeObject(userNew);
                var jsonC = json;
                lh.LogMessageToFile("json PRIMER JSON" + jsonC);
                dynamic dynJson = JsonConvert.DeserializeObject(jsonC);
                CRUD_gnt_clientes_season_ctas ctsS = new CRUD_gnt_clientes_season_ctas();
                ctsS.idgnt_clientes_season_ctas = 0;
                ctsS.idgnt_seasons = cuenta.idgnt_seasons;
                ctsS.idgnt_clientesInfo = Convert.ToInt32(cuenta.idgnt_clientesInfo);
                ctsS.cuentasMeta = dynJson.Login;
                ctsS.leverage = Convert.ToInt32(userNew.Leverage);
                ctsS.balance = userNew.Balance;
                ctsS.operacion = "C";
                lh.LogMessageToFile("cuentasMeta : " + ctsS.cuentasMeta);
                lh.LogMessageToFile("MainPassword : " + dynJson.MainPassword);
                lh.LogMessageToFile("email : " + cuenta.email);
                string mailE = co.enviaCorreoMt5(ctsS.cuentasMeta.ToString(), cuenta.mainPassword, "GNTCapital-Live", cuenta.email);
                lh.LogMessageToFile("mailE : " + mailE);
                salida = mdb.CRUD_gnt_clientes_season_ctas(ctsS, st);
                dynamic msjeSalida = new JObject();
                msjeSalida.mensaje = "Cuenta agregada a Season";
                msjeSalida.password = cuenta.mainPassword;
                msjeSalida.cuentasMeta = ctsS.cuentasMeta.ToString();
                msjeSalida.idgnt_clientesInfo = cuenta.idgnt_clientesInfo;
                json = JsonConvert.SerializeObject(msjeSalida);
                salida = "[" + json + "]";
                lh.LogMessageToFile("salida : " + salida);
                lh.LogMessageToFile("json SEGUNDO JSON" + salida);
            }
            catch(Exception e)
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

        public string cambioPassword(Password pwd, Conector conectorGNT, StringConect st)
        {
            string salida = null;
            var json = "";
            MetaQuotes.MT5WebAPI.MTRetCode codes;
            Correo co = new Correo();
            CrearSeason_ctas mdb = new CrearSeason_ctas();
            ConectMT5 gnt = new ConectMT5();
            m_WebApi = gnt.conect(conectorGNT);
            string pass = mdb.getPassword(st);
            codes = m_WebApi.UserPasswordChange(pwd.loginCambio, pass);
            m_WebApi.Disconnect();
            if(codes.ToString() == "MT_RET_OK" || codes.ToString() == "-1")
            {
                salida = mdb.CRUD_gnt_cuentastrade(pass, (int)pwd.loginCambio, pwd.idgnt_clientesInfo, st);
                salida = co.enviaCorreoMt5Pass(pwd.loginCambio.ToString(), pass, pwd.tipo, pwd.correo);
                cambioContrasena cambio = new cambioContrasena();
                cambio.Login = pwd.loginCambio;
                cambio.contrasena = pass;
                json = JsonConvert.SerializeObject(cambio);
            }
            else
            {
                salida = "Error en servidor" + codes.ToString();
            }
            return salida;
        }

        public class cambioContrasena
        {
            public string contrasena { get; set; }
            public ulong Login { get; set; }
        }
    }
}
