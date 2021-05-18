using System;
using System.Collections.Generic;

namespace PruebaTecnicaVivianaLargo.Models
{
    public partial class Balance
    {
        public int Id { get; set; }
        public int IdTransaccion { get; set; }
        public int IdPagador { get; set; }
        public int IdComercio { get; set; }
        

        public virtual Comercios IdComercioNavigation { get; set; }
        public virtual Pagadores IdPagadorNavigation { get; set; }
        public virtual Transacciones IdTransaccionNavigation { get; set; }
    }
}
