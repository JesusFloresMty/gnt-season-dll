using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.Modelos
{
    public class StringConect
    {
        /*Objeto para poder conectarte a una Base de datos en este caso gnt_mdb*/
        public string server { get; set; }
        public string uid { get; set; }
        public string pwd { get; set; }
        public string database { get; set; }
    }
}
