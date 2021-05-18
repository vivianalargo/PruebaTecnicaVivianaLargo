using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaVivianaLargo.Models;


using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PruebaTecnicaVivianaLargo.Repositorios;
using PruebaTecnicaVivianaLargo.Enums;

namespace PruebaTecnicaVivianaLargo.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TransaccionesController : ControllerBase
    {
        [HttpPost]
        public ActionResult CargarTransacciones(InfoAcceso infoUsuario)
        {

            var listaBalance = new List<Balance>(0);
            var listaTransacciones = new List<Transacciones>(0);
            var resultado = new List<Object>(0);
            var Json = new Object();
            var usuario = new Usuarios();
            var pagador = new Pagadores();
            var comercio = new Comercios();
            var transaccion = new Transacciones();

            try
            {
                using (var db = new pruebaTecnicaContext())
                {
                    switch(infoUsuario.TipoPerfil)
                    {
                        case 1:
                            pagador = db.Pagadores.Where(x => x.IdUsuario.Equals(infoUsuario.Id)).SingleOrDefault(); 
                            listaBalance = db.Balance.Where(x => x.IdPagador.Equals(pagador.Id)).ToList();
                            break;
                        case 2:
                            comercio = db.Comercios.Where(x => x.IdUsuario.Equals(infoUsuario.Id)).SingleOrDefault();
                            listaBalance = db.Balance.Where(x => x.IdComercio.Equals(comercio.Id)).ToList();
                            break;
                    }


                    foreach (var item in listaBalance)
                    {
                        transaccion = db.Transacciones.Find(item.IdTransaccion);
                        listaTransacciones.Add(transaccion);
                    }
                }

                foreach (var item in listaTransacciones)
                {
                    Json = (new
                    {
                        codigo = item.Codigo,
                        concepto = item.Concepto,
                        fecha = item.Fecha,
                        monto = item.Monto,
                        medio = ((Trans_Medio_Pago)item.MedioPago).ToString(),
                        estado = ((Trans_Estado)item.Estado).ToString()
                    });
                    
                    
                    resultado.Add(Json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(new { Resultado = resultado});
        }

        [HttpPost]
        public string GuardarTransaccion(InfoTransaccion infoTransaccion)
        {

            try
            {
                using (var db = new pruebaTecnicaContext())
                {
                    Transacciones transaccion = new Transacciones();
                    Balance balance = new Balance();
                    Pagadores pagador = new Pagadores();

                    pagador = db.Pagadores.Where(x => x.IdUsuario.Equals(infoTransaccion.idUSuario)).SingleOrDefault();


                    transaccion.Concepto = infoTransaccion.Concepto;
                    transaccion.Codigo = infoTransaccion.Codigo;
                    transaccion.Fecha = DateTime.Now;
                    transaccion.Monto = infoTransaccion.Monto;
                    transaccion.MedioPago = infoTransaccion.MedioPago;
                    transaccion.Estado = 999;


                    db.Transacciones.Add(transaccion);
                    db.SaveChanges();

                    balance.IdComercio = infoTransaccion.Comercio;
                    balance.IdPagador = pagador.Id;
                    balance.IdTransaccion = transaccion.Id;


                    db.Balance.Add(balance);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "Datos Actualizados";

        }



        [HttpPost]
        public ActionResult BuscarTransaccion(infoCriterioBusqueda infoCriterioBusqueda)
        {
            List<Transacciones> transacciones = new List<Transacciones>(0);
            List<Balance> balances = new List<Balance>(0);
            List<Pagadores> pagadores = new List<Pagadores>(0);
            var Json = new Object();
            var resultado = new List<Object>(0);

            try
            {
                using (var contexto = new pruebaTecnicaContext())
                {


                    balances = contexto.Balance.Where(x => x.IdComercio == infoCriterioBusqueda.Comercio).ToList();

                    if (infoCriterioBusqueda.Pagador != null && infoCriterioBusqueda.Pagador > 0)
                    {
                        balances = balances.Where(x => x.IdPagador == infoCriterioBusqueda.Pagador).ToList();

                    }

                    if (infoCriterioBusqueda.CodigoTransaccion != null && infoCriterioBusqueda.Fecha != null)
                    {
                        transacciones = (from b in balances
                                         join t in contexto.Transacciones on b.IdTransaccion equals t.Id
                                         where (t.Codigo == infoCriterioBusqueda.CodigoTransaccion)
                                         || (t.Fecha.Value.ToString("yyyy-MM-dd") == infoCriterioBusqueda.Fecha.Value.ToString("yyyy-MM-dd"))
                                         select t).ToList();

                    }

                    if (infoCriterioBusqueda.CodigoTransaccion != null && infoCriterioBusqueda.Fecha == null)
                    {
                        transacciones = (from b in balances
                                         join t in contexto.Transacciones on b.IdTransaccion equals t.Id
                                         where (t.Codigo == infoCriterioBusqueda.CodigoTransaccion)
                                         select t).ToList();

                    }

                    if (infoCriterioBusqueda.CodigoTransaccion == null && infoCriterioBusqueda.Fecha != null)
                    {
                        
                        transacciones = (from b in balances
                                         join t in contexto.Transacciones on b.IdTransaccion equals t.Id
                                         where (t.Fecha.Value.ToString("yyyy-MM-dd") == infoCriterioBusqueda.Fecha.Value.ToString("yyyy-MM-dd"))
                                         select t).ToList();

                    }

                    if (infoCriterioBusqueda.CodigoTransaccion == null && infoCriterioBusqueda.Fecha == null)
                    {
                        transacciones = (from b in balances
                                         join t in contexto.Transacciones on b.IdTransaccion equals t.Id
                                         select t).ToList();

                    }

                    foreach (var item in transacciones)
                    {
                        Json = (new
                        {
                            codigo = item.Codigo,
                            concepto = item.Concepto,
                            fecha = item.Fecha,
                            monto = item.Monto,
                            medio = ((Trans_Medio_Pago)item.MedioPago).ToString(),
                            estado = ((Trans_Estado)item.Estado).ToString()
                        });


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
