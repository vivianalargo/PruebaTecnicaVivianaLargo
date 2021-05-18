using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaVivianaLargo.Models
{
    public class infoCriterioBusqueda
    {
        public int? Pagador { get; set; }
        public int? CodigoTransaccion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Comercio { get; set; }

    }
}
