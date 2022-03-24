using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAgendaDTO
{
    public class EliminarContactoResponse : Resultado
    {

        public EliminarContactoResponse() {
            MensajeRespuesta = string.Empty;
            CodigoMensaje = string.Empty;
            MensajeSistemas = string.Empty;
            Estatus = false;
        }
    }
}
