using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PruebaTecnicaVivianaLargo.Models
{
    public class InfoImportadaAPI
    {
        [JsonProperty(PropertyName = "comercio_codigo")]
        public int Comercio_codigo
        { get;set;}
        [JsonProperty(PropertyName = "comercio_nombre")]
        public string Comercio_nombre
        { get; set; }
        [JsonProperty(PropertyName = "comercio_nit")]
        public string Comercio_nit
        { get; set; }
        [JsonProperty(PropertyName = "comercio_direccion")]
        public string Comercio_direccion
        { get; set; }
        [JsonProperty(PropertyName = "trans_codigo")]
        public int Trans_codigo
        { get; set; }
        [JsonProperty(PropertyName = "trans_medio_pago")]
        public int Trans_medio_pago
        { get; set; }
        [JsonProperty(PropertyName = "trans_estado")]
        public int Trans_estado
        {get;set;}
        [JsonProperty(PropertyName = "trans_total")]
        public float Trans_total
        { get; set; }
        [JsonProperty(PropertyName = "trans_fecha")]
        public string Trans_fecha
        { get; set; }
        [JsonProperty(PropertyName = "trans_concepto")]
        public string Trans_concepto
        { get; set; }
        [JsonProperty(PropertyName = "usuario_identificacion")]
        public string Usuario_identificacion
        { get; set; }
        [JsonProperty(PropertyName = "usuario_nombre")]
        public string Usuario_nombre
        { get; set; }
        [JsonProperty(PropertyName = "usuario_email")]
        public string Usuario_email
        { get; set; }


    }
}
