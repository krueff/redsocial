using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedSocialBusiness;
using RedSocialEntity;
using RedSocialComun;
using RedSocialWebUtil;

public partial class Registracion : System.Web.UI.Page
{
    private UsuarioBO boUsuario = new UsuarioBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            for (int i = DateTime.Now.Year; i > 1904; i--)
            {
                ddlAnio.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }

    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.Nombre = txtNombre.Text;
            usuario.Email = txtEmail.Text;
            usuario.Password = txtPassword.Text;
            switch (btn.ID)
            {
                case "btnRegistrarMusico":
                    usuario.Perfil = 'M';
                    usuario.musico = new MusicoEntity();
                    usuario.musico.Genero = txtGenero.Text;
                    usuario.musico.FechaNacimiento = Util.ObtenerFecha(
                        int.Parse(ddlAnio.SelectedValue),
                        int.Parse(ddlMes.SelectedValue));
                    break;
                case "btnRegistrarLugar":
                    usuario.Perfil = 'L';
                    usuario.lugar = new LugarEntity();
                    usuario.lugar.DirCalle = txtCalle.Text;
                    usuario.lugar.DirNumero = int.Parse(txtAltura.Text);
                    break;
            }
            usuario.Provincia = ddlProvincia.SelectedItem.Text;
            usuario.Ciudad = ddlCiudad.SelectedItem.Text;
            
            boUsuario.Registrar(usuario);

            SessionHelper.AlmacenarUsuarioAutenticado(boUsuario.Autenticar(usuario.Email, usuario.Password));
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(SessionHelper.UsuarioAutenticado.Email, false);
        }
        catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }
}