using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAgendaDAO.Mensajes
{
    /// <summary>
    /// Control interno de mensajes del Web Services.
    /// </summary>
    public class Mensaje
    {
        #region Mensajes Comunes
        public static string MSG001 = "La Base de Datos está tardando en Responder, vuelva a intentarlo en unos minutos.";
        #endregion

        #region Mensaje Nuevo Contacto
        public static string MSG002 = "-3";
        public static string MSG003 = "Ocurrió un Error al tratar de guardar la información del Nuevo Contacto, inténtelo más tarde.";
        #endregion

        #region Mensaje Editar Contacto
        public static string MSG004 = "-4";
        public static string MSG005 = "Ocurrió un Error al tratar de actualizar la información del Contacto, inténtelo más tarde.";
        #endregion

        #region Mensaje Eliminar contacto
        public static string MSG006 = "-5";
        public static string MSG007 = "Ocurrio un Error al tratar de eliminar la información del contacto, inténtelo mós tarde.";
        #endregion
    }
}
