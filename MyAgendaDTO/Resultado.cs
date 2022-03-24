using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace MyAgendaDTO
{
    [DataContract]
    public class Resultado
    {

        public Resultado() {
            MensajeRespuesta = string.Empty;
            CodigoMensaje = string.Empty;
            MensajeSistemas = string.Empty;
            Estatus = false;
        }

        [DataMember(Order = 1)]
        public bool Estatus { get; set; }

        [DataMember(Order = 2)]
        public string MensajeRespuesta { get; set; }

        [DataMember(Order = 3)]
        public string CodigoMensaje { get; set; }

        [DataMember(Order = 4)]
        public string MensajeSistemas { get; set; }
    }
}
