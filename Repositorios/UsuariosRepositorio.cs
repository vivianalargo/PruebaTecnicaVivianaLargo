using PruebaTecnicaVivianaLargo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaVivianaLargo.Repositorios
{
    public class UsuariosRepositorio : GenericRepository<Usuarios>, IUsuariosRepositorio
    {
        public UsuariosRepositorio(pruebaTecnicaContext context) : base(context)
        {
            //_context = context;
        }
    }
}
