using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.Modelos
{
    public class CrearCuenta
    {
        public string idgnt_clientesInfo { get; set; }
        public string name { get; set; }
        public string email { set; get; }
        public string mainPassword { get; set; }
        public string group { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public double balance { get; set; }
        public uint leverage { get; set; }
        public string tipoServidor { get; set; }
        public int idgnt_seasons { get; set; }
        public string depositText { get; set; }
    }
}
