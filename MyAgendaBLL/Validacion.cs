using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyAgendaDTO;
using msg = MyAgendaSA.Mensaje;


namespace MyAgendaBLL
{
    public class Validacion
    {
         public static bool ParametrosRequeridosNuevoContacto(AgregarNuevoContactoRequest request, ref string mensaje) {
            bool parametrosValidos = false;

            if (request.DatosConsumoAgregar != null)
            {
                if (!string.IsNullOrEmpty(request.DatosConsumoAgregar.Usuario) && !string.IsNullOrEmpty(request.DatosConsumoAgregar.Metodo) &&
                    !string.IsNullOrEmpty(request.DatosConsumoAgregar.Aplicacion) && !string.IsNullOrEmpty(request.Numero))
                {
                    parametrosValidos = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(request.DatosConsumoAgregar.Usuario))
                        mensaje = msg.Mensaje.MSG002;
                    else if (string.IsNullOrEmpty(request.DatosConsumoAgregar.Metodo))
                        mensaje = msg.Mensaje.MSG003;
                    else if (string.IsNullOrEmpty(request.DatosConsumoAgregar.Aplicacion))
                        mensaje = msg.Mensaje.MSG004;
                    else if (string.IsNullOrEmpty(request.Numero))
                        mensaje = msg.Mensaje.MSG005;
                }
            }
            else
                mensaje = msg.Mensaje.MSG001;
            return parametrosValidos;
        }

        public static bool ParametrosRequeridosEditarContacto(EditarContactoRequest request, ref string mensaje) {
            bool parametrosValidos = false;
            if (request.DatosConsumoEditar != null)
            {
                if (!string.IsNullOrEmpty(request.DatosConsumoEditar.Usuario) && !string.IsNullOrEmpty(request.DatosConsumoEditar.Metodo) &&
                    !string.IsNullOrEmpty(request.DatosConsumoEditar.Aplicacion) && !string.IsNullOrEmpty(request.Numero))
                {
                    parametrosValidos = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(request.DatosConsumoEditar.Usuario))
                        mensaje = msg.Mensaje.MSG002;
                    else if (string.IsNullOrEmpty(request.DatosConsumoEditar.Metodo))
                        mensaje = msg.Mensaje.MSG003;
                    else if (string.IsNullOrEmpty(request.DatosConsumoEditar.Aplicacion))
                        mensaje = msg.Mensaje.MSG004;
                    else if (string.IsNullOrEmpty(request.Numero))
                        mensaje = msg.Mensaje.MSG005;
                }
            }
            else
                mensaje = msg.Mensaje.MSG001;

            return parametrosValidos;
        }

        public static bool ParametrosRequeridosEliminarContacto(EliminarContactoRequest request, ref string mensaje) {
            bool parametrosValidos = false;
            if (request.DatosConsumoEliminar!=null)
            {
                if (!string.IsNullOrEmpty(request.DatosConsumoEliminar.Usuario) && !string.IsNullOrEmpty(request.DatosConsumoEliminar.Metodo) &&
                    !string.IsNullOrEmpty(request.DatosConsumoEliminar.Aplicacion) && !string.IsNullOrEmpty(request.Numero))
                {
                    parametrosValidos = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(request.DatosConsumoEliminar.Usuario))
                        mensaje = msg.Mensaje.MSG002;
                    else if (string.IsNullOrEmpty(request.DatosConsumoEliminar.Metodo))
                        mensaje = msg.Mensaje.MSG003;
                    else if (string.IsNullOrEmpty(request.DatosConsumoEliminar.Aplicacion))
                        mensaje = msg.Mensaje.MSG004;
                    else if (string.IsNullOrEmpty(request.Numero))
                        mensaje = msg.Mensaje.MSG005;
                }
	
            }
            else
                mensaje = msg.Mensaje.MSG001;
            return parametrosValidos;
        }
    }
}
