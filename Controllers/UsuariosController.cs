using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaTecnicaVivianaLargo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaVivianaLargo.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsuariosController : ControllerBase
    {
        //// GET: api/<UsuariosController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UsuariosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UsuariosController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UsuariosController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UsuariosController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpPost]
        public ActionResult validarUsuario(InfoAcceso infoUsuario)
        {
            var Json = new object();

            using (var db = new pruebaTecnicaContext())
            {
                var usuaiobd = db.Usuarios.Where(x => x.Usuario == infoUsuario.Usuario).SingleOrDefault();

                //Si existe devuelva
                if (usuaiobd != null)
                {
                    Json = (new
                    {
                        idUsuario = usuaiobd.Id,
                        idTipoPerfil = usuaiobd.TipoPerfil,
                        contrasenia = usuaiobd.Contrasenia,
                        usuario = usuaiobd.Usuario
                    });
                }
                else
                {
                    Json = (new { idUsuario = -1, idTipoPerfil = -1, contrasenia = -1, usuario = -1 });
                }

            }

            return Ok(new { results = Json });

        }

        [HttpPost]
        public string GuardarUsuario(InfoAcceso infoUsuario)
        {

            try
            {
                using (var db = new pruebaTecnicaContext())
                {

                    var usuariobd = db.Usuarios.Find(infoUsuario.Id);

                    if (usuariobd != null)
                    {
                        usuariobd.Usuario = infoUsuario.Usuario;
                        usuariobd.Contrasenia = infoUsuario.Contrasenia;
                        //El usuario debe asignar los datos de acceso 
                        db.Usuarios.Update(usuariobd);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "Datos Actualizados";

        }
    }
}
