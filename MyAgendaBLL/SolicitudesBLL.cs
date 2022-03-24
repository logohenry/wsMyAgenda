using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyAgendaDAO;
using MyAgendaDTO;

namespace MyAgendaBLL
{
    public class SolicitudesBLL
    {
        public AgregarNuevoContactoResponse AgregarNuevoContactoBLL(AgregarNuevoContactoRequest request)
        {
            bool estatusValidacion = false;
            string mensajeValidacion = string.Empty;

            AgregarNuevoContactoResponse response = null;
            PropAgendaDAO peticion = new PropAgendaDAO();

            estatusValidacion = Validacion.ParametrosRequeridosNuevoContacto(request, ref mensajeValidacion);
            if (estatusValidacion)
            {
                response = peticion.AgregarNuevoContactoDAO(request);
            }
            else {
                GeneraRespuestaNuevoContacto(ref response,estatusValidacion,mensajeValidacion, string.Empty,string.Empty);
            }
            peticion = null;
            return response;
        }

        public EditarContactoResponse EditarContactoBLL(EditarContactoRequest request) {

            bool estattusValidacion = false;
            string mensajeValidacion = string.Empty;

            EditarContactoResponse response = null;
            PropAgendaDAO peticion = new PropAgendaDAO();

            estattusValidacion = Validacion.ParametrosRequeridosEditarContacto(request, ref mensajeValidacion);

            if (estattusValidacion)
                response = peticion.EditarContactoDAO(request);
            else
                GeneraRespuestaEditarContacto(ref response, estattusValidacion, mensajeValidacion, string.Empty, string.Empty);


            peticion = null;
            return response ;
        }

        public EliminarContactoResponse EliminarContactoBLL(EliminarContactoRequest request) {

            bool estatusValidacion = false;
            string mensajeValidacion = string.Empty;

            EliminarContactoResponse response = null;
            PropAgendaDAO peticion = new PropAgendaDAO();

            estatusValidacion = Validacion.ParametrosRequeridosEliminarContacto(request, ref mensajeValidacion);
            if (estatusValidacion)
                response = peticion.EliminarContactoDAO(request);
            else
                GenerarRespuestaEliminarContacto(ref response, estatusValidacion, mensajeValidacion, string.Empty, string.Empty);

            peticion = null;
            return response;
        }

        public List<MyAgenda> BuscarContactoBLL(int IdContacto) {
            List<MyAgenda> myAgenda = new List<MyAgenda>();

            return myAgenda;
        }
        private void GenerarRespuestaEliminarContacto(ref EliminarContactoResponse Response, bool Estatus, string Respuesta, string CodigoMensaje, string Excepcion)
        {
            if (Response ==null)
            {
                Response = new EliminarContactoResponse();
            }

            Response.MensajeRespuesta = Respuesta;
            Response.CodigoMensaje = CodigoMensaje;
            Response.MensajeSistemas = Excepcion;
            Response.Estatus = Estatus;
        }

        private void GeneraRespuestaEditarContacto(ref EditarContactoResponse Response, bool Estatus, string Respuesta, string CodigoMensaje, string Exception)
        {
            if (Response == null)
                Response = new EditarContactoResponse();

            Response.MensajeRespuesta = Respuesta;
            Response.CodigoMensaje = CodigoMensaje;
            Response.MensajeSistemas = Exception;
            Response.Estatus = Estatus;
        }

        private void GeneraRespuestaNuevoContacto(ref AgregarNuevoContactoResponse Response, bool Estatus, string Respuesta, string CodigoMensaje, string Exception)
        {
            if (Response == null)
                Response = new AgregarNuevoContactoResponse();

            Response.MensajeRespuesta = Respuesta;
            Response.CodigoMensaje = CodigoMensaje;
            Response.MensajeSistemas = Exception;
            Response.Estatus = Estatus;
        }
    }
}
