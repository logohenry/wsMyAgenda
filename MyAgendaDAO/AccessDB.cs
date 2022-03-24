using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MyAgendaDAO
{/// <summary>
/// Clase que nos permite establecer las cadenas de conexion a las que se conecta el proyecto.
/// </summary>
    public class AccessDB
    {
        /// <summary>
        /// Tipo string. Cadena de conexion para la Base de Datos EJEMPLODB.
        /// </summary>
        public static string EJEMPLODB {
            get { return ConfigurationManager.ConnectionStrings["CnnStr"].ToString ();  }
        }
    }
}
