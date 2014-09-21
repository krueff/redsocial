using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSocialComun;

namespace RedSocialEntity
{
    public class UsuarioEntity
    {
        public UsuarioEntity()
        {
            Id = 0;
            Nombre = "";
            Perfil = ' ';
            Email = "";
            Password = "";
            Tipo = "";
            Provincia = "";
            Ciudad = "";
            Foto = null;
            FechaRegistracion = DateTime.Now;
            FechaActualizacion = null;
            musico = null;
            lugar = null;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public char Perfil { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Foto { get; set; }
        public DateTime FechaRegistracion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public MusicoEntity musico {get; set;}
        public LugarEntity lugar { get; set; }


        public void ValidarDatos()
        {
            if (Nombre.Trim() == "" ||
                Email.Trim() == "" ||
                Password.Trim() == "" ||
                Provincia == "" ||
                Ciudad == "")
            {
                throw new DatosObligatoriosExcepcion();
            }

            if (!Util.EsEmail(Email))
            {
                throw new EmailExcepcion();
            }
        }
    }
}
