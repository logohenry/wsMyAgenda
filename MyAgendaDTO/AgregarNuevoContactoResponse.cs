using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAgendaDTO
{
    public class AgregarNuevoContactoResponse : Resultado
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AgregarNuevoContactoResponse() {
            MensajeRespuesta = string.Empty;
            CodigoMensaje = string.Empty;
            MensajeSistemas = string.Empty;
            Estatus = false;
        }
    }
}
