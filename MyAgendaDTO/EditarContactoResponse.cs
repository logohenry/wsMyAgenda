using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAgendaDTO
{
    public class EditarContactoResponse : Resultado
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EditarContactoResponse()
        {
            MensajeRespuesta = string.Empty;
            CodigoMensaje = string.Empty;
            MensajeSistemas = string.Empty;
            Estatus = false;
        }
    }
}
