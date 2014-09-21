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
    public class UsuarioDA
    {
        public UsuarioDA()
        {
        }

        #region Métodos Privados
        private UsuarioEntity CrearUsuario(SqlDataReader cursor)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.Id = cursor.GetInt32(cursor.GetOrdinal("UsuarioID"));
            usuario.Nombre = cursor.GetString(cursor.GetOrdinal("UsuarioNombre"));
            usuario.Perfil =char.Parse( cursor.GetValue(cursor.GetOrdinal("UsuarioPerfil")).ToString());
            usuario.Email = cursor.GetString(cursor.GetOrdinal("UsuarioEmail"));
            usuario.Password = cursor.GetString(cursor.GetOrdinal("UsuarioPassword"));
            usuario.Provincia = cursor.GetString(cursor.GetOrdinal("UsuarioProvincia"));
            usuario.Ciudad = cursor.GetString(cursor.GetOrdinal("UsuarioCiudad"));

            if (!cursor.IsDBNull(cursor.GetOrdinal("UsuarioFoto")))
                usuario.Foto = cursor.GetString(cursor.GetOrdinal("UsuarioFoto"));

            usuario.FechaRegistracion = cursor.GetDateTime(cursor.GetOrdinal("UsuarioFechaRegistracion"));

            if (!cursor.IsDBNull(cursor.GetOrdinal("UsuarioFechaActualizacion")))
                usuario.FechaActualizacion = cursor.GetDateTime(cursor.GetOrdinal("UsuarioFechaActualizacion"));

            switch (usuario.Perfil)
            {
                case 'M': usuario.musico = new MusicoEntity();
                    usuario.musico.FechaNacimiento = cursor.GetDateTime(cursor.GetOrdinal("UsuarioFechaNacimiento"));
                    usuario.musico.Genero = cursor.GetString(cursor.GetOrdinal("UsuarioGenero"));
                    if (!cursor.IsDBNull(cursor.GetOrdinal("CuentaYoutube")))
                        usuario.musico.CuentaYoutube = cursor.GetString(cursor.GetOrdinal("CuentaYoutube"));

                    if (!cursor.IsDBNull(cursor.GetOrdinal("CuentaFacebook")))
                        usuario.musico.CuentaFacebook = cursor.GetString(cursor.GetOrdinal("CuentaFacebook"));

                    if (!cursor.IsDBNull(cursor.GetOrdinal("CuentaSoundCloud")))
                        usuario.musico.CuentaSoundCloud = cursor.GetString(cursor.GetOrdinal("CuentaSoundCloud"));

                    if (!cursor.IsDBNull(cursor.GetOrdinal("CuentaTwitter")))
                        usuario.musico.CuentaTwitter = cursor.GetString(cursor.GetOrdinal("CuentaTwitter"));
                    break;

                default: usuario.lugar = new LugarEntity();
                    usuario.lugar.DirCalle = cursor.GetString(cursor.GetOrdinal("DirCalle"));
                    usuario.lugar.DirNumero = cursor.GetInt32(cursor.GetOrdinal("DirNro"));

                    if (!cursor.IsDBNull(cursor.GetOrdinal("HorarioDesde")))
                        usuario.lugar.HorarioDesde = cursor.GetString(cursor.GetOrdinal("HorarioDesde"));

                    if (!cursor.IsDBNull(cursor.GetOrdinal("HorarioHasta")))
                        usuario.lugar.HorarioHasta = cursor.GetString(cursor.GetOrdinal("HorarioHasta"));
                    break;
            }

            return usuario;
        }
        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(UsuarioEntity usuario)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {

                    switch (usuario.Perfil)
                    {
                        case 'M':
                            using (SqlCommand comando = new SqlCommand("MusicoInsert", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                SqlCommandBuilder.DeriveParameters(comando);

                                comando.Parameters["@UsuarioID"].Direction = ParameterDirection.Output;
                                comando.Parameters["@UsuarioGenero"].Value = usuario.musico.Genero.Trim();
                                comando.Parameters["@UsuarioFechaNacimiento"].Value = usuario.musico.FechaNacimiento;
                                comando.Parameters["@UsuarioNombre"].Value = usuario.Nombre.Trim();
                                comando.Parameters["@UsuarioPerfil"].Value = usuario.Perfil;
                                comando.Parameters["@UsuarioEmail"].Value = usuario.Email.Trim();
                                comando.Parameters["@UsuarioPassword"].Value = usuario.Password.Trim();
                                comando.Parameters["@UsuarioProvincia"].Value = usuario.Provincia;
                                comando.Parameters["@UsuarioCiudad"].Value = usuario.Provincia;
                                comando.Parameters["@UsuarioFechaRegistracion"].Value = usuario.FechaRegistracion;
                                comando.ExecuteNonQuery();
                                usuario.Id = Convert.ToInt32(comando.Parameters["@UsuarioID"].Value);
                            }

                        break;
                        case 'L':
                            using (SqlCommand comando = new SqlCommand("LugarInsert", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                SqlCommandBuilder.DeriveParameters(comando);

                                comando.Parameters["@UsuarioID"].Direction = ParameterDirection.Output;
                                comando.Parameters["@UsuarioNombre"].Value = usuario.Nombre.Trim();
                                comando.Parameters["@UsuarioPerfil"].Value = usuario.Perfil;
                                comando.Parameters["@UsuarioEmail"].Value = usuario.Email.Trim();
                                comando.Parameters["@UsuarioPassword"].Value = usuario.Password.Trim();
                                comando.Parameters["@UsuarioProvincia"].Value = usuario.Provincia;
                                comando.Parameters["@UsuarioCiudad"].Value = usuario.Ciudad;
                                comando.Parameters["@UsuarioFechaRegistracion"].Value = usuario.FechaRegistracion;
                                comando.Parameters["@DirCalle"].Value = usuario.lugar.DirCalle.Trim();
                                comando.Parameters["@DirNro"].Value = usuario.lugar.DirNumero;
                                comando.ExecuteNonQuery();
                                usuario.Id = Convert.ToInt32(comando.Parameters["@RETURN_VALUE"].Value);
                            }

                        break;
                    }


                    

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el usuario.", ex);
            }
        }

        public void Actualizar(int id, string nombreArchivo, byte[] archivoFoto)
        {
            try
            {
                FileInfo infoArchivo = new FileInfo(nombreArchivo);

                string rutaFotos = ConfigurationManager.AppSettings["RutaFotos"];
                string nuevoNombreArchivo = id.ToString() + infoArchivo.Extension;

                using (FileStream archivo = File.Create(rutaFotos + nuevoNombreArchivo))
                {
                    archivo.Write(archivoFoto, 0, archivoFoto.Length);
                    archivo.Close();
                }

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioActualizarFoto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioID"].Value = id;
                        comando.Parameters["@UsuarioFoto"].Value = nuevoNombreArchivo;
                        comando.ExecuteNonQuery();
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar la foto.", ex);
            }
        }

        public bool ExisteEmail(string email)
        {
            try
            {
                bool existeEmail;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscarEmail", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioEmail"].Value = email.Trim();
                        existeEmail = Convert.ToBoolean(comando.ExecuteScalar());
                    }

                    conexion.Close();
                }

                return existeEmail;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email.", ex);
            }
        }

        public UsuarioEntity BuscarUsuario(string email, string password)
        {
            try
            {
                UsuarioEntity usuario = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscarPorEmailPassword", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioEmail"].Value = email.Trim();
                        comando.Parameters["@UsuarioPassword"].Value = password.Trim();

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                usuario = CrearUsuario(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }
        
        public List<UsuarioEntity> Buscar(string Nombre) 
        {
            try 
            {
                List<UsuarioEntity> usuarios = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion()) 
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscar", conexion)) 
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioNombre"].Value = Nombre.Trim();

                        using (SqlDataReader cursor = comando.ExecuteReader()) 
                        {
                            usuarios = new List<UsuarioEntity>();

                            while (cursor.Read())
                            { 
                                usuarios.Add(CrearUsuario(cursor));
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return usuarios;
            }
            catch(Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar.", ex);
            }
        }
        #endregion Métodos Públicos
    }
}
