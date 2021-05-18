using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaVivianaLargo.Models;

namespace PruebaTecnicaVivianaLargo.Controllers
{
    //[Route("[api/controller]")]
    //[ApiController]
    public class PagadoresController : ControllerBase
    {
        // GET: api/<UsuariosController>
        [HttpGet]
        public ActionResult Get()
        {
            
            var listaPagadores = new List<Pagadores>(0);
            var resultado = new List<Object>(0);
            var Json = new Object();

            var pagador = new Comercios();

            try
            {
                using (var db = new pruebaTecnicaContext())
                {

                    listaPagadores = db.Pagadores.ToList();

                    foreach (var item in listaPagadores)
                    {
                        Json = (new
                        {
                            codigo = item.Nombre,
                            id = item.Id

                        }); ; ;

                        resultado.Add(Json);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(new { Resultado = resultado });
        }
    }
}
