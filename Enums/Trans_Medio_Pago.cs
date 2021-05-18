using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaVivianaLargo.Enums
{
    enum Trans_Medio_Pago : int
    {
        [EnumMember]
        tarjetaCredito = 32,
        [EnumMember]
        pse = 29,
        [EnumMember]
        gana = 41,
        [EnumMember]
        caja = 42,
        [EnumMember]
        sinDefinir = 0
    }
}
