using System;
using System.Collections.Generic;

namespace PruebaTecnicaVivianaLargo.Models
{
    public partial class Comercios
    {
        public Comercios()
        {
            Balance = new HashSet<Balance>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string? Direccion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuarios IdNavigation { get; set; }
        public virtual ICollection<Balance> Balance { get; set; }
    }
}
