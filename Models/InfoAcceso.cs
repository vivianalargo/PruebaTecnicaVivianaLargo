using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaVivianaLargo.Models
{
    public class InfoAcceso
    {
        public int Id { get; set; }
        public int TipoPerfil { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
