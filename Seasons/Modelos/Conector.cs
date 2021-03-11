using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.Modelos
{
    public class Conector
    {
        /*Objeto para poder conectarte a un servidor de MT5, las credenciales deben de solicitarse*/
        public string server { get; set; }
        public int port { get; set; }
        public ulong login { get; set; }
        public string password { get; set; }
        public string servidor { get; set; }
        public uint timeout { get; set; }
    }
}
