using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedSocialBusiness;
using RedSocialWebUtil;

public partial class Busqueda : System.Web.UI.Page
{
    UsuarioBO usuario = new UsuarioBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Nombre = Request.QueryString["Nombre"];
        BuscarUsuarios(Nombre);
    }

    private void BuscarUsuarios(string Nombre)
    {
        try
        {
            dgResultados.DataSource = usuario.Buscar(Nombre);
            dgResultados.DataBind();
        }
        catch (AutenticacionExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }
}