using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSocialDataSQLServer;

namespace RedSocialBusiness
{
    public class AutocompletarBO
    {
        private AutocompletarDA boAutocomp;
        public AutocompletarBO()
        {
            boAutocomp = new AutocompletarDA();
        }

        public List<string> GetNombres(string UsuarioNombre)
        {
            return boAutocomp.GetNombres(UsuarioNombre);
        }
    }
}
