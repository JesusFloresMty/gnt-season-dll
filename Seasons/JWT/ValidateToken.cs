using Newtonsoft.Json;
using Seasons.Modelos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.JWT
{
    public class ValidateToken
    {
        Logger.LogHandler lh = new Logger.LogHandler();

        public string validateJWT(string token)
        {
            string salida = null;
            var json = "";
            try
            {
                token = token.StartsWith("Bearer ") ? token.Substring(7) : token;
                var stream = token;
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
                var jti = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
                salida = jti;
            }
            catch (Exception e)
            {
                lh = new Logger.LogHandler();
                ErrorHandler error = new ErrorHandler();
                error.error = e.ToString();
                error.code = "600";
                error.mensaje = "ERROR validateJWT()";
                json = JsonConvert.SerializeObject(error);
                lh.LogMessageToFile("ERROR validateJWT() : " + json);
                salida = e.ToString();
            }
            return salida;
        }
    }
}
