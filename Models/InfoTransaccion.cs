using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaVivianaLargo.Models
{
    public class InfoTransaccion
    {
        public string Concepto { get; set; }
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public float Monto { get; set; }
        public int MedioPago { get; set; }
        public int  Comercio { get; set; }
        public int  idUSuario { get; set; }
        
    }
}
