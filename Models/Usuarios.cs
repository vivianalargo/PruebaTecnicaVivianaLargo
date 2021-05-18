using PruebaTecnicaVivianaLargo.Enums;
using System;
using System.Collections.Generic;

namespace PruebaTecnicaVivianaLargo.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Pagadores = new HashSet<Pagadores>();
        }

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public Tipo_Perfil TipoPerfil { get; set; }

        public virtual Comercios Comercios { get; set; }
        public virtual ICollection<Pagadores> Pagadores { get; set; }
    }
}
