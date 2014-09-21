<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Autenticado.master" CodeFile="Busqueda.aspx.cs" Inherits="Busqueda" %>


<asp:Content ID="cphBuscar" ContentPlaceHolderID="Cuerpo" Runat="Server">

    <asp:GridView id="dgResultados" runat="server" AutoGenerateColumns="False" DataKeyNames="Nombre" CssClass="Busqueda" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
	    <Columns>
		    <asp:BoundField DataField="Id" HeaderText="UsuarioID"></asp:BoundField>
		    <asp:BoundField DataField="Perfil" HeaderText="Perfil"></asp:BoundField>
		    <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
		    <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
		    <asp:BoundField DataField="Provincia" HeaderText="Provincia"></asp:BoundField>
		    <asp:BoundField DataField="Ciudad" HeaderText="Ciudad"></asp:BoundField>
            <asp:commandfield HeaderText="" ShowSelectButton="True" SelectText="Agregar a mis amigos" ButtonType="Button" ControlStyle-CssClass="AgregarAmigo"/>
	    </Columns>
    </asp:GridView>

</asp:Content>
