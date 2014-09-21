using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSocialEntity
{
    public class SolicitudEntity
    {
        public SolicitudEntity()
        {
            SolicitudId = 0;
            UsuarioId = 0;
            UsuarioIdSolicita = 0;
            SolicitudEstadoId = 0;
            FechaAlta = DateTime.Now;
            FechaModificacion = null;
        }

        public int SolicitudId { get; set; }
        public int UsuarioId { get; set; }
        public int UsuarioIdSolicita { get; set; }
        public int SolicitudEstadoId { get; set; }
        public DateTime FechaAlta { get; set; }
        public Nullable<DateTime> FechaModificacion { get; set; }
    }
}
