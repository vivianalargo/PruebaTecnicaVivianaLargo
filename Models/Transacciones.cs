using System;
using System.Collections.Generic;

namespace PruebaTecnicaVivianaLargo.Models
{
    public partial class Transacciones
    {
        public Transacciones()
        {
            Balance = new HashSet<Balance>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string? Concepto { get; set; }
        public DateTime? Fecha { get; set; }
        public double Monto { get; set; }
        public int MedioPago { get; set; }
        public int Estado { get; set; }
        public virtual ICollection<Balance> Balance { get; set; }
    }
}
