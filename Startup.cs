using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



using System.IO;
using System.Net;
using System.Text;

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PruebaTecnicaVivianaLargo.Models;
using PruebaTecnicaVivianaLargo.Enums;

namespace PruebaTecnicaVivianaLargo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "api/{controller}/{action}");

            });

            GetInfoApi(); 
        }


        private void GetInfoApi()
        {
            //throw new NotImplementedException();

            //string responseBody = "";
            var url = "http://pbiz.zonavirtual.com/api/Prueba/Consulta?param7";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {

                        StreamReader reader = new StreamReader(strReader, Encoding.UTF8);
                        var jsonReader = new JsonTextReader(reader);
                        var serializer = new Newtonsoft.Json.JsonSerializer();
                        var listaInfoApi = serializer.Deserialize<List<InfoImportadaAPI>>(jsonReader);

                        using (var db = new pruebaTecnicaContext())
                        {
                            foreach (var i in listaInfoApi)
                            {
                                Pagadores pagador = new Pagadores();
                                Comercios comercio = new Comercios();
                                Transacciones transaccion = new Transacciones();
                                Usuarios usuarioPagador = new Usuarios();
                                Usuarios usuarioComercio = new Usuarios();
                                Balance relMovimiento = new Balance();

                                usuarioComercio.Usuario = i.Comercio_codigo.ToString();
                                usuarioComercio.Contrasenia = i.Comercio_codigo.ToString();
                                usuarioComercio.TipoPerfil = Tipo_Perfil.Comercio;

                                var idUsuario = 0;
                                var existe = db.Usuarios.Where(x => x.Usuario == usuarioComercio.Usuario).SingleOrDefault();//Find(usuarioComercio.Usuario);
                                if (existe == null)
                                {
                                    db.Usuarios.Add(usuarioComercio);
                                    db.SaveChanges();
                                    idUsuario = usuarioComercio.Id;
                                }
                                else
                                {
                                    //Actualice
                                    idUsuario = existe.Id;
                                }

                                comercio.Id = i.Comercio_codigo;
                                comercio.Nombre = i.Comercio_nombre;
                                comercio.Nit = i.Comercio_nit;
                                comercio.Direccion = i.Comercio_direccion;
                                comercio.IdUsuario = idUsuario;

                                var idComercio = 0;
                                var existeC = db.Comercios.Find(comercio.Id);
                                if (existeC == null)
                                {
                                    db.Comercios.Add(comercio);
                                    db.SaveChanges();
                                    idComercio = comercio.Id;
                                }
                                else
                                {
                                    idComercio = existeC.Id;
                                }

                                usuarioPagador.Usuario = i.Usuario_identificacion;
                                usuarioPagador.Contrasenia = i.Usuario_identificacion;
                                usuarioPagador.TipoPerfil = Tipo_Perfil.Pagador;

                                var existeP = db.Usuarios.Where(x => x.Usuario == usuarioPagador.Usuario).SingleOrDefault();//Find(usuarioComercio.Usuario);
                                if (existeP == null)
                                {
                                    db.Usuarios.Add(usuarioPagador);
                                    db.SaveChanges();
                                    idUsuario = usuarioPagador.Id;
                                }
                                else
                                {
                                    idUsuario = existeP.Id;
                                }

                                pagador.Identificacion = i.Usuario_identificacion;
                                pagador.Nombre = i.Usuario_nombre;
                                pagador.Email = i.Usuario_email;
                                pagador.IdUsuario = idUsuario;

                                var idPagador = 0;
                                var existeP2 = db.Pagadores.Where(x => x.Identificacion == pagador.Identificacion).SingleOrDefault();
                                if (existeP2 == null)
                                {
                                    db.Pagadores.Add(pagador);
                                    db.SaveChanges();
                                    idPagador = pagador.Id;
                                }
                                else
                                {
                                    idPagador = existeP2.Id;
                                }


                                transaccion.Codigo = i.Trans_codigo;
                                transaccion.MedioPago = i.Trans_medio_pago;
                                //transaccion.estado = i.Trans_estado;
                                transaccion.Concepto = i.Trans_concepto;
                                transaccion.Monto = i.Trans_total;
                                transaccion.Fecha = Convert.ToDateTime(i.Trans_fecha.Replace(".",""));
                                transaccion.Estado = i.Trans_estado;

                                var idTransacion = 0;
                                var existeT = db.Transacciones.Where(x => x.Codigo == transaccion.Codigo).SingleOrDefault();
                                if (existeT == null)
                                {
                                    db.Transacciones.Add(transaccion);
                                    db.SaveChanges();
                                    idTransacion = transaccion.Id;
                                }
                                else
                                {
                                    idTransacion = existeT.Id;
                                }


                                /*relMovimiento.IdTransaccion = transaccion.Id;
                                relMovimiento.IdPagador = pagador.Id;
                                relMovimiento.IdComercio = comercio.Id;*/
                                relMovimiento.IdTransaccion = idTransacion;
                                relMovimiento.IdPagador = idPagador;
                                relMovimiento.IdComercio = idComercio;
                                //relMovimiento.Estado = i.Trans_estado;

                                db.Balance.Add(relMovimiento);
                                db.SaveChanges();

                            }
                        }

                    }
                }
            }
            catch (WebException ex)
            {
                // Handle e
            }
        }
    }
}
