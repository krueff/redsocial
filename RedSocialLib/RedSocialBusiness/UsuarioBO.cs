﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSocialEntity;
using RedSocialData;
using RedSocialDataSQLServer;

namespace RedSocialBusiness
{
    public class UsuarioBO
    {
        private UsuarioDA daUsuario;

        public UsuarioBO()
        {
            daUsuario = new UsuarioDA();
        }

        public UsuarioEntity Autenticar(string email, string password)
        {
            try
            {
                UsuarioEntity usuario = daUsuario.BuscarUsuario(email, password);

                if (usuario == null)
                    throw new AutenticacionExcepcionBO();

                return usuario;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

        public void Registrar(UsuarioEntity usuario)
        {
            try
            {
                usuario.ValidarDatos();

                if (daUsuario.ExisteEmail(usuario.Email))
                    throw new EmailExisteExcepcionBO();

                daUsuario.Insertar(usuario);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

        public void ActualizarFoto(int id, string nombreArchivo, byte[] archivoFoto)
        {
            try
            {
                daUsuario.Actualizar(id, nombreArchivo, archivoFoto);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo actualizar la foto.", ex);
            }
        }

        public List<UsuarioEntity> Buscar(string Nombre)
        {
            try
            {
                return daUsuario.Buscar(Nombre);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la busqueda.", ex);
            }
        }
    }
}
