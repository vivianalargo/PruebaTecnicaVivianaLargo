using System;
using System.Collections.Generic;

namespace PruebaTecnicaVivianaLargo.Models
{
    public partial class Pagadores
    {
        public Pagadores()
        {
            Balance = new HashSet<Balance>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string? Email { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Balance> Balance { get; set; }
    }
}
