using System.Runtime.Serialization;

namespace MyAgendaDTO
{
    [DataContract]
    public class MyAgenda
    {
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public int IdTipoIdentificacion { get; set; }
        [DataMember]
        public int Idenificacion { get; set; }
        
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Apellidos { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public int Number { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Gender { get; set; }
/*
        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public string Correo { get; set; }
        */
        [DataMember]
        public string FechaRegistro { get; set; }

    }
}
