using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaVivianaLargo.Enums
{
    [DataContract]
    enum Trans_Estado : int
    {
        [EnumMember]
        Aprobada = 1,
        [EnumMember]
        Rechazada = 1000,
        [EnumMember]
        Pendiente = 999,
        [EnumMember]
        RechazadaSR = 1001
    }
}
