using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.Modelos
{
    public class CRUD_gnt_clientes_season_ctas
    {
        public int idgnt_clientes_season_ctas { get; set; }
        public int idgnt_seasons { get; set; }
        public int idgnt_clientesInfo { get; set; }
        public int cuentasMeta { get; set; }
        public int leverage { get; set; }
        public double balance { get; set; }
        public string operacion { get; set; }
    }
}
