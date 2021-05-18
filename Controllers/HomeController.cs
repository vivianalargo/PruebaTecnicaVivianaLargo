using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PruebaTecnicaVivianaLargo.Models;
using PruebaTecnicaVivianaLargo.Repositorios;

namespace PruebaTecnicaVivianaLargo.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ////string responseBody = "";
            //var url = "http://pbiz.zonavirtual.com/api/Prueba/Consulta?param7";
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //request.Accept = "application/json";

            //try
            //{
            //    using (WebResponse response = request.GetResponse())
            //    {
            //        using (Stream strReader = response.GetResponseStream())
            //        {

            //            /*var format = "dd/MM/yyyy HH:mm:ss"; // your datetime format
            //            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };*/

            //            StreamReader reader = new StreamReader(strReader, Encoding.UTF8);
            //            var jsonReader = new JsonTextReader(reader);
            //            var serializer = new Newtonsoft.Json.JsonSerializer();
            //            var listaInfoApi = serializer.Deserialize<List<InfoImportadaAPI>>(jsonReader);

            //            using (var db = new pruebaTecnicaContext())
            //            {
            //                /*var blog = new Blog { Url = "http://sample.com" };
            //                db.Blogs.Add(blog);
            //                db.SaveChanges();*/
                            
            //                foreach (var i in listaInfoApi)
            //                {
            //                    Pagadores pagador = new Pagadores();
            //                    Comercios comercio = new Comercios();
            //                    Transacciones transaccion = new Transacciones();
            //                    Usuarios usuarioPagador = new Usuarios();
            //                    Usuarios usuarioComercio = new Usuarios();
            //                    Balance relMovimiento = new Balance();

            //                    usuarioComercio.Usuario = i.Comercio_codigo.ToString();
            //                    usuarioComercio.Contrasenia = i.Comercio_codigo.ToString();
            //                    usuarioComercio.TipoPerfil = 0;

            //                    /*UsuariosRepositorio repo = new UsuariosRepositorio(db);
            //                    repo.Add(usuarioComercio);*/

            //                    /*db.Usuarios.Add(usuarioComercio);
            //                    db.SaveChanges();*/

            //                    var idUsuario = 0;
            //                    var existe = db.Usuarios.Where(x => x.Usuario == usuarioComercio.Usuario).SingleOrDefault();//Find(usuarioComercio.Usuario);
            //                    if (existe == null)
            //                    {
            //                        db.Usuarios.Add(usuarioComercio);
            //                        db.SaveChanges();
            //                        idUsuario = usuarioComercio.Id;
            //                    }
            //                    else
            //                    {
            //                        //Actualice
            //                        idUsuario = existe.Id;
            //                    }

                                


            //                    comercio.Id = i.Comercio_codigo;
            //                    comercio.Nombre = i.Comercio_nombre;
            //                    comercio.Nit = i.Comercio_nit;
            //                    comercio.Direccion = i.Comercio_direccion;
            //                    comercio.IdUsuario = idUsuario;


            //                    /*db.Comercios.Add(comercio);
            //                    db.SaveChanges();*/


            //                    var existeC = db.Comercios.Find(comercio.Id);
            //                    if (existeC == null)
            //                    {
            //                        db.Comercios.Add(comercio);
            //                        db.SaveChanges();
            //                    }
            //                    else
            //                    {
            //                        //Actualice
            //                    }

                                


            //                    usuarioPagador.Usuario = i.Usuario_identificacion;
            //                    usuarioPagador.Contrasenia = i.Usuario_identificacion;
            //                    usuarioPagador.TipoPerfil = 0;


            //                    /*db.Usuarios.Add(usuarioPagador);
            //                    db.SaveChanges();*/


            //                    var existeP = db.Usuarios.Where(x => x.Usuario == usuarioPagador.Usuario).SingleOrDefault();//Find(usuarioComercio.Usuario);
            //                    if (existeP == null)
            //                    {
            //                        db.Usuarios.Add(usuarioPagador);
            //                        db.SaveChanges();
            //                        idUsuario = usuarioPagador.Id;
            //                    }
            //                    else
            //                    {
            //                        //Actualice
            //                        idUsuario = existeP.Id;
            //                    }

                                


            //                    pagador.Identificacion = i.Usuario_identificacion;
            //                    pagador.Nombre = i.Usuario_nombre;
            //                    pagador.Email = i.Usuario_email;
            //                    pagador.IdUsuario = idUsuario;


            //                    /*db.Pagadores.Add(pagador);
            //                    db.SaveChanges();*/

            //                    var existeP2 = db.Pagadores.Where(x => x.Identificacion == pagador.Identificacion).SingleOrDefault();
            //                    if (existeP2 == null)
            //                    {
            //                        db.Pagadores.Add(pagador);
            //                        db.SaveChanges();
            //                    }
            //                    else
            //                    {
            //                        //Actualice
            //                    }

                                


            //                    transaccion.Codigo = i.Trans_codigo;
            //                    transaccion.MedioPago = i.Trans_medio_pago;
            //                    //transaccion.estado = i.Trans_estado;
            //                    transaccion.Monto = i.Trans_total;
            //                    //transaccion.Fecha = Convert.ToDateTime(i.Trans_fecha.Remove('.'));


            //                    /*db.Transacciones.Add(transaccion);
            //                    db.SaveChanges();*/


            //                    var existeT = db.Transacciones.Where(x => x.Codigo == transaccion.Codigo).SingleOrDefault();
            //                    if (existeT == null)
            //                    {
            //                        db.Transacciones.Add(transaccion);
            //                        db.SaveChanges();
            //                    }
            //                    else
            //                    {
            //                        //Actualice
            //                    }

                                
            //                    /*

            //                    relMovimiento.IdTransaccion = transaccion.Id;
            //                    relMovimiento.IdPagador = pagador.Id;
            //                    relMovimiento.IdComercio = comercio.Id;
            //                    relMovimiento.Estado = i.Trans_estado;


            //                    db.Balance.Add(relMovimiento);
            //                    db.SaveChanges();*/

            //                }


                            
            //            }
                        
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    // Handle e
            //}


            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
