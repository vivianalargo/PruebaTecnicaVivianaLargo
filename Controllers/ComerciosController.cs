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
    public class ComerciosController : ControllerBase
    {
        // GET: api/<UsuariosController>
        [HttpGet]
        public ActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            var listaComercios = new List<Comercios>(0);
            var resultado = new List<Object>(0);
            var Json = new Object();

            var comercio = new Comercios();

            try
            {
                using (var db = new pruebaTecnicaContext())
                {

                    listaComercios= db.Comercios.ToList();

                    foreach (var item in listaComercios)
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
