using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.JWT
{
    public class JWTModel
    {
        public string hashCode { get; set; }
        public int idgnt_clientesInfo { get; set; }
        public string email { get; set; }
        public int idIB { get; set; }
        public int idSIB { get; set; }
        public int cuentasMeta { get; set; }
        public string tipo { get; set; }
    }
}
