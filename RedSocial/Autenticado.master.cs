using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;
using RedSocialEntity;
using RedSocialWebUtil;

[PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
public partial class Autenticado : System.Web.UI.MasterPage
{
    UsuarioEntity usuario;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            usuario = (UsuarioEntity)HttpContext.Current.Session["UsuarioAutenticado"];
            txtBuscar.Text = Request.QueryString["Nombre"];
        }
    }

    protected void btnBuscar_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("Busqueda.aspx?Nombre=" + txtBuscar.Text);
    }


    protected void btnAmigo_Click(object sender, System.EventArgs e)
    {

    }

    protected void Submit(object sender, EventArgs e)
    {
        string customerName = Request.Form[txtBuscar.UniqueID];
    }

    protected void TextBox1_TextChanged(object sender, System.EventArgs e)
    {

    }
}
