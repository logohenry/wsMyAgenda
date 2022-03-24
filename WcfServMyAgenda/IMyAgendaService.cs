using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyAgendaDTO;

namespace WcfServMyAgenda
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyAgendaService" in both code and config file together.
    [ServiceContract ]
    public interface IMyAgendaService
    {

        [OperationContract]
        EliminarContactoResponse EliminarContacto(EliminarContactoRequest Request);

        [OperationContract]
        MyAgenda BuscarContacto(int IdContacto);

        [OperationContract]
        List<MyAgenda> mostrarContactos();

        [OperationContract]
        AgregarNuevoContactoResponse NuevoContacto(AgregarNuevoContactoRequest Request);

        [OperationContract]
        EditarContactoResponse EditarContacto(EditarContactoRequest Request);
    }   
}
