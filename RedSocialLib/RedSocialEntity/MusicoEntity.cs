using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSocialComun;

namespace RedSocialEntity
{
    public class MusicoEntity
    {
        public MusicoEntity()
        {
            FechaNacimiento = DateTime.Now;
            Genero = "";
            CuentaYoutube = "";
            CuentaFacebook = "";
            CuentaSoundCloud = "";
            CuentaTwitter = "";
        }

        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string CuentaYoutube { get; set; }
        public string CuentaFacebook { get; set; }
        public string CuentaSoundCloud { get; set; }
        public string CuentaTwitter { get; set; }

        public void ValidarDatos() 
        {
            if (FechaNacimiento == DateTime.MinValue ||
                Genero == "")
            {
                throw new DatosObligatoriosExcepcion();
            }
        }
    }
}
