using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {

        public List<ContactoModel> Listar() { 
        
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) { 
            
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read())
                    {

                        oLista.Add(new ContactoModel()
                        {

                            idContacto = Convert.ToInt32(dr["IdContacto"]),
                            nombre = dr["Nombre"].ToString(),
                            telefono = dr["Telefono"].ToString(),
                            correo = dr["Correo"].ToString()

                        });

                    }

                }

            }

        return oLista;
            
        }

        public ContactoModel Obtener(int IdContacto)
        {

            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oContacto.idContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.nombre = dr["Nombre"].ToString();
                        oContacto.telefono = dr["Telefono"].ToString();
                        oContacto.correo = dr["Correo"].ToString();

                    }

                }

            }

            return oContacto;

        }

        public bool Guardar(ContactoModel oContacto) {

            bool rpta;

            try 
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                rpta = true;

            } 
            catch (Exception e) 
            {
            
                string error = e.Message;
                rpta = false;
            
            }

            return rpta;
        
        }

        public bool Editar(ContactoModel oContacto)
        {

            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", oContacto.idContacto);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                rpta = true;

            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;

            }

            return rpta;

        }

        public bool Eliminar(int IdContacto)
        {

            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                rpta = true;

            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;

            }

            return rpta;

        }

    }
}
