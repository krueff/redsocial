using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSocialEntity
{
    public class LugarEntity
    {
        public LugarEntity()
        {
            HorarioDesde = "";
            HorarioHasta = "";
            DirCalle = "";
            DirNumero = 0;
        }

        public string HorarioDesde { get; set; }
        public string HorarioHasta { get; set; }
        public string DirCalle { get; set; }
        public int DirNumero { get; set; }

        public void ValidarDatos()
        {
            if (DirCalle == "" ||
                DirNumero == 0)
            {
                throw new DatosObligatoriosExcepcion();
            }
        }
    }
}
