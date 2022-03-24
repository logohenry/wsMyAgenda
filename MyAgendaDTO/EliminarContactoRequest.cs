using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MyAgendaDTO
{
    [DataContract]
    public class EliminarContactoRequest
    {

        public EliminarContactoRequest() {
            DatosConsumoEliminar = new DatosConsumo();
            Numero = string.Empty;
        }

        [DataMember(Order = 1)]
        public DatosConsumo DatosConsumoEliminar { get; set; }

        [DataMember(Order = 2)]
        public string Numero { get; set; }

    }
}
