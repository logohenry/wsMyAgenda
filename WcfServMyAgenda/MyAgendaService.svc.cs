using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MyAgendaDTO;
using MyAgendaBLL;
using MyAgendaDAO;
using Transaccion.Datos;
using Sp = MyAgendaDAO.StoredProcedure.CatalogoSp;


namespace WcfServMyAgenda
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyAgendaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyAgendaService.svc or MyAgendaService.svc.cs at the Solution Explorer and start debugging.
    public class MyAgendaService : IMyAgendaService
    {
        string cnxstr = ConfigurationManager.ConnectionStrings["CnnStr"].ConnectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public AgregarNuevoContactoResponse NuevoContacto(AgregarNuevoContactoRequest Request)
        {
            SolicitudesBLL bll = new SolicitudesBLL();
              return bll.AgregarNuevoContactoBLL(Request);
        }

        public EditarContactoResponse EditarContacto(EditarContactoRequest Request)
        {
            SolicitudesBLL bll = new SolicitudesBLL();
            return bll.EditarContactoBLL(Request);
        }
       public MyAgenda BuscarContacto(int IdContacto)
        {
            MyAgenda myAgenda = new MyAgenda();
            //SolicitudesBLL bll = new SolicitudesBLL();
            //return bll.BuscarContactoBLL(IdContacto);

            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Number", IdContacto);
                
                using (SqlDataReader dr = SqlHelper.ExecuteReader(AccessDB.EJEMPLODB, CommandType.StoredProcedure, Sp.spsConsultarContacto, param) )
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

        public int EliminarContacto(int IdContacto)
        {
            int res = 0;

            try
            {

                SqlParameter[] param = new SqlParameter[1];

                SqlConnection cnn = new SqlConnection(cnxstr);
                cnn.Open();

                SqlCommand cmd = new SqlCommand("Contacto_spd", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Number", IdContacto);

                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Elimiar. " + ex.Message);
            }
            return res;
        }

        public List<MyAgenda> mostrarContactos()
        {
            List<MyAgenda> lista = new List<MyAgenda>();

            try
            {
                SqlConnection cnn = new SqlConnection(cnxstr);
                cnn.Open();

                SqlCommand cmd = new SqlCommand("Contacto_spc", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new MyAgenda
                        {
                            Number = Convert.ToInt32(rd["Number"].ToString()),
                            FirstName = rd["First_Name"].ToString(),
                            MiddleName = rd["Middle_Name"].ToString(),
                            LastName = rd["Last_Name"].ToString(),
                            Gender = rd["Gender"].ToString(),
                            Telefono = rd["Telefono"].ToString(),
                            FechaRegistro = rd["Fecha_Registro"].ToString(),
                            Correo = rd["Correo"].ToString()
                        });

                    }

                }
                else
                {
                    throw new Exception("No hay registros.");
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Elimiar. " + ex.Message);
            }
            return lista;
        }

        public EliminarContactoResponse EliminarContacto(EliminarContactoRequest Request)
        {
            SolicitudesBLL bll = new SolicitudesBLL();
            return bll.EliminarContactoBLL(Request);
        }
    }
}
