using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MyAgendaDTO
{
    public class AgregarNuevoContactoRequest
    {
        public AgregarNuevoContactoRequest() {
            DatosConsumoAgregar = new DatosConsumo();
            Numero = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            MiddleName = string.Empty;
            Gender = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;

            //FechaRegistro = string.Empty;

        }

        /// <summary>
        /// Datos del  invocador
        /// </summary>
        [DataMember(Order = 1)]        
        public DatosConsumo DatosConsumoAgregar { get; set; }

        [DataMember(Order = 2)]
        public string Numero { get; set; }

        [DataMember(Order = 3)]
        public string FirstName { get; set; }

        [DataMember(Order = 4)]
        public string LastName { get; set; }

        [DataMember(Order = 5)]
        public string MiddleName { get; set; }

        [DataMember(Order = 6)]
        public string Gender { get; set; }

        [DataMember(Order = 7)]
        public string Telefono { get; set; }

        [DataMember(Order = 8)]
        public string Correo { get; set; }

        //[DataMember(Order = 9)]
        //public string FechaRegistro { get; set; }
    }
}
