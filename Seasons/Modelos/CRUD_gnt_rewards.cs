using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.Modelos
{
    public class CRUD_gnt_rewards
    {
        public int idgnt_rewards { get; set; }
        public int idgnt_seasons { get; set; }
        public double balanceCtas { get; set; }
        public double lotes { get; set; }
        public string operacion { get; set; }
    }
}
