using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using RedSocialEntity;
using RedSocialData;

namespace RedSocialDataSQLServer
{
    public class AutocompletarDA
    {
        public AutocompletarDA()
        {
        }

        public List<string> GetNombres(string UsuarioNombre)
        {
            try
            {
                List<string> usuarios = new List<string>();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscar", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioNombre"].Value = UsuarioNombre.Trim();

                        using (SqlDataReader sdr = comando.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                usuarios.Add(sdr["UsuarioNombre"].ToString());
                            }
                        }
                        conexion.Close();
                    }
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar.", ex);
            }
        }
    }
}
