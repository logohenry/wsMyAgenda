using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MyAgendaDTO
{
    [DataContract ]
    public class DatosConsumo
    {
        /// <summary>
        /// Nombre de la aplicación que está haciendo la llamada
        /// </summary>
        [DataMember(Order = 1, IsRequired = true, EmitDefaultValue = false)]
        public string Aplicacion { get; set; }

        /// <summary>
        /// Nombre del método desde donde se está haciendo la llamada.
        /// </summary>
        [DataMember(Order = 3, IsRequired = true, EmitDefaultValue = false)]
        public string Metodo { get; set; }

        /// <summary>
        /// Nombre del usuario de red o ejecutivo que esta haciendo la llamada.
        /// </summary>
        [DataMember(Order = 4, IsRequired = true, EmitDefaultValue = false)]
        public string Usuario { get; set; }

    }
}
