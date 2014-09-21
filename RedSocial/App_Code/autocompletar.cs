using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using RedSocialBusiness;

///<summary>
/// Summary description for Service
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
[System.Web.Script.Services.ScriptService]
public class autocompletar : System.Web.Services.WebService
{
    private AutocompletarBO autocomp;
    public autocompletar()
    {
        autocomp = new AutocompletarBO();
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<string> GetNombres(string UsuarioNombre)
    {
        return autocomp.GetNombres(UsuarioNombre);
    }
}