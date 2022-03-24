using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyAgendaDTO;
using System.Data;
using System.Data.SqlClient;
//using Invercap.Data;
using Transaccion.Datos;
using Sp = MyAgendaDAO.StoredProcedure.CatalogoSp;
using Msg = MyAgendaDAO.Mensajes.Mensaje;


namespace MyAgendaDAO
{
    public class PropAgendaDAO
    {
        /// <summary>
        /// Método para agregar un nuevo contacto a la Agenda
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AgregarNuevoContactoResponse AgregarNuevoContactoDAO(AgregarNuevoContactoRequest request) {

            string estatus = string.Empty;
            string CodMensaje = string.Empty;
            SqlParameter[] param = new SqlParameter[7];
            AgregarNuevoContactoResponse response = new AgregarNuevoContactoResponse();

            try {

                param[0] = new SqlParameter("@Number", request.Numero);
                param[1] = new SqlParameter("@First_Name", request.FirstName);
                param[2] = new SqlParameter("@Last_Name", request.LastName);
                param[3] = new SqlParameter("@Middle_Name", request.MiddleName);
                param[4] = new SqlParameter("@Gender", request.Gender);
                param[5] = new SqlParameter("@Telefono", request.Telefono);
                param[6] = new SqlParameter("@Correo", request.Correo);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(AccessDB.EJEMPLODB, CommandType.StoredProcedure, Sp.spiNuevoContacto, param))
                {

                    while (dr.Read())
                    {
                        if (!String.IsNullOrEmpty(dr["MENSAJE"].ToString()))
                            estatus = dr["MENSAJE"].ToString().Trim();

                        if (!String.IsNullOrEmpty(dr["CodigoMensaje"].ToString()))
                            CodMensaje = dr["CodigoMensaje"].ToString().Trim();
                    }
                }
                if (CodMensaje == "0")
                    GenerarRespuestaNuevoContacto(ref response, true,estatus,CodMensaje,string.Empty);
                else
                    GenerarRespuestaNuevoContacto(ref response, false, estatus, CodMensaje, string.Empty);

            }
            catch (TimeoutException Ex)
            {
                GenerarRespuestaNuevoContacto(ref response, false, Msg .MSG001, Msg.MSG002, Ex.Message);
            }
            catch (Exception ex)
            {
                GenerarRespuestaNuevoContacto(ref response, false, Msg.MSG003, Msg.MSG002, ex.Message);
            }
            finally {
                param = null;
                estatus = null;
                CodMensaje = null;
            }

            return response;
        }

        /// <summary>
        /// Función que nos permite Editar la información de un contacto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EditarContactoResponse EditarContactoDAO(EditarContactoRequest request) {

            string estatus = string.Empty;
            string CodMensaje = string.Empty;
            SqlParameter[] param = new SqlParameter[7];
            EditarContactoResponse response = new EditarContactoResponse();

            try
            {

                param[0] = new SqlParameter("@Number", request.Numero);
                param[1] = new SqlParameter("@First_Name", request.FirstName);
                param[2] = new SqlParameter("@Last_Name", request.LastName);
                param[3] = new SqlParameter("@Middle_Name", request.MiddleName);
                param[4] = new SqlParameter("@Gender", request.Gender);
                param[5] = new SqlParameter("@Telefono", request.Telefono);
                param[6] = new SqlParameter("@Correo", request.Correo);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(AccessDB.EJEMPLODB, CommandType.StoredProcedure, Sp.spuEditarContacto, param))
                {

                    while (dr.Read())
                    {
                        if (!String.IsNullOrEmpty(dr["MENSAJE"].ToString()))
                            estatus = dr["MENSAJE"].ToString().Trim();

                        if (!String.IsNullOrEmpty(dr["CodigoMensaje"].ToString()))
                            CodMensaje = dr["CodigoMensaje"].ToString().Trim();
                    }
                }
                if (CodMensaje == "1")
                    GenerarRespuestaEditarContacto(ref response, true, estatus, CodMensaje, string.Empty);
                else
                    GenerarRespuestaEditarContacto(ref response, false, estatus, CodMensaje, string.Empty);

            }
            catch (TimeoutException Ex)
            {
                GenerarRespuestaEditarContacto(ref response, false, Msg.MSG001, Msg.MSG004, Ex.Message);
            }
            catch (Exception ex)
            {
                GenerarRespuestaEditarContacto(ref response, false, Msg.MSG005, Msg.MSG004, ex.Message);
            }
            finally
            {
                param = null;
                estatus = null;
                CodMensaje = null;
            }

            return response;


        }

        public MyAgenda  BuscarContactoDAO(int IdContacto) {
            MyAgenda myAgenda = new MyAgenda();

            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Number", IdContacto);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(AccessDB.EJEMPLODB, CommandType.StoredProcedure, Sp.spsConsultarContacto, param))
                {
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            myAgenda.Number = Convert.ToInt32(dr["Number"].ToString());
                            myAgenda.FirstName = dr["First_Name"].ToString();
                            myAgenda.MiddleName = dr["Middle_Name"].ToString();
                            myAgenda.LastName = dr["Last_Name"].ToString();
                            myAgenda.Gender = dr["Gender"].ToString();
                            myAgenda.Telefono = dr["Telefono"].ToString();
                            myAgenda.FechaRegistro = dr["Fecha_Registro"].ToString();
                            myAgenda.Correo = dr["correo"].ToString();
                        }
                    }
                    else
                    {
                        throw new Exception("No hay registros.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha encontrado el contacto. " + ex.Message);
            }
            return myAgenda;
        }
        public EliminarContactoResponse EliminarContactoDAO(EliminarContactoRequest request) {
            string estatus = string.Empty;
            string CodMensaje = string.Empty;

            SqlParameter[] param = new SqlParameter[1];
            EliminarContactoResponse response = new EliminarContactoResponse();

            try
            {
                param[0] = new SqlParameter("@Number", request.Numero);
                using (SqlDataReader dr = SqlHelper.ExecuteReader(AccessDB.EJEMPLODB, CommandType.StoredProcedure, Sp.spdEliminarContacto, param))
                {
                    while (dr.Read())
                    {
                        if (!String.IsNullOrEmpty(dr["MENSAJE"].ToString()))
                            estatus = dr["MENSAJE"].ToString().Trim();

                        if (!String.IsNullOrEmpty(dr["CodigoMensaje"].ToString()))
                            CodMensaje = dr["CodigoMensaje"].ToString().Trim();
                    }
                }
                if (CodMensaje == "0")
                    GenerarRespuestaEliminarContacto(ref response, true, estatus, CodMensaje, string.Empty);
                else
                    GenerarRespuestaEliminarContacto(ref response, false, estatus, CodMensaje, string.Empty);
            }

            catch (TimeoutException Ex)
            {
                GenerarRespuestaEliminarContacto(ref response, false, Msg.MSG001, Msg.MSG006, Ex.Message);
            }
            catch (Exception ex)
            {
                GenerarRespuestaEliminarContacto(ref response, false, Msg.MSG007, Msg.MSG006, ex.Message);
            }

            finally
            {
                param = null;
                estatus = null;
                CodMensaje = null;
            }

            return response;

        }

        private void GenerarRespuestaEliminarContacto(ref EliminarContactoResponse Response, bool Estatus, string Respuesta, string CodigoMensaje, string Exception)
        {
            Response.MensajeSistemas = Respuesta;
            Response.CodigoMensaje = CodigoMensaje;
            Response.Estatus = Estatus;
        }

        private void GenerarRespuestaEditarContacto(ref EditarContactoResponse Response, bool Estatus, string Respuesta, string CodigoMensaje, string Exception)
        {
            Response.MensajeSistemas = Respuesta;
            Response.CodigoMensaje = CodigoMensaje;
            Response.Estatus = Estatus;
        }

        private void GenerarRespuestaNuevoContacto(ref AgregarNuevoContactoResponse Response, bool Estatus, string Respuesta, string CodigoMensaje, string Exception)
        {

            Response.MensajeSistemas = Respuesta;
            Response.CodigoMensaje = CodigoMensaje;
            Response.Estatus = Estatus;
        }
        
    }
}
