using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaVivianaLargo.Enums
{
    [DataContract]
    public enum Tipo_Perfil : int
        {
        [EnumMember]
        Pagador = 1,
        [EnumMember]
        Comercio = 2,
        [EnumMember]
        Sin_Definir = 0
        }

}
