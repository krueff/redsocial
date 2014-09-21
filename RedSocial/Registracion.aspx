<%@ Page Title="" Language="C#" MasterPageFile="~/SinAutenticar.master" AutoEventWireup="true" CodeFile="Registracion.aspx.cs" Inherits="Registracion"%>

<asp:Content ID="cphContenido" ContentPlaceHolderID="Cuerpo" Runat="Server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#hide").click(function () {
                $("#Lugar").hide();
                $("#Musico").fadeToggle();
                $("#show").css({ "color": "rgba(255,255,255,0.5)"});
                $("#hide").css({ "color": "rgba(255,255,255,1)" });
            });
            $("#show").click(function () {
                $("#Lugar").fadeToggle();
                $("#Musico").hide();
                $("#hide").css({ "color": "rgba(255,255,255,0.5)"});
                $("#show").css({ "color": "rgba(255,255,255,1)" });
            });
            $('#hide').css('cursor', 'pointer');
            $('#show').css('cursor', 'pointer');
        });
    </script>

    <asp:Panel runat="server" ID="panFondo" CssClass="background">
        <asp:Panel runat="server" ID="panTitulo" CssClass="Titulo"></asp:Panel>
        <asp:Panel runat="server" ID="panRegistraciom" CssClass="CajaRegistracion">
        <asp:Panel ID="panPerfil" runat="server" CssClass="selPerfil">
            <asp:Label ID="lblSel" runat="server" Text="Seleccione su perfil:&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="cajaRegistracionTitulo"></asp:Label>
            <a id="hide" class="Seleccion">Músico</a>
            <a id="show" class="Seleccion" style="color: rgba(255,255,255,0.5);">Lugar</a>
        </asp:Panel>
            <asp:Table runat="server" ID="tblRegistracion" CellSpacing="8">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox ID="txtNombre" runat="server" Columns="30" MaxLength="30" placeholder="Nombre" CssClass="CajaTextoRegistracion"></asp:TextBox>            
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:TextBox ID="txtEmail" runat="server" Columns="30" MaxLength="100" placeholder="Tu correo electrónico" CssClass="CajaTextoRegistracion"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:TextBox ID="txtPassword" runat="server" Columns="30" MaxLength="10" TextMode="Password" placeholder="Contraseña" CssClass="CajaTextoRegistracion"></asp:TextBox>                
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <div id="Musico" style="display: block;">
                <asp:Table runat="server" ID="tabRegistroMusico" CellSpacing="8">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:TextBox ID="txtGenero" runat="server" Columns="30" MaxLength="100" placeholder="Género" CssClass="CajaTextoRegistracion"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:DropDownList ID="ddlProvincia" runat="server">
                                <asp:ListItem Value="0" Text="Capital Federal"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlCiudad" runat="server">
                                <asp:ListItem Value="0" Text="Almagro"></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlMes" runat="server">
                                <asp:ListItem Value="0" Text="Mes"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Ene"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Abr"></asp:ListItem>
                                <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                <asp:ListItem Value="8" Text="Agos"></asp:ListItem>
                                <asp:ListItem Value="9" Text="Sept"></asp:ListItem>
                                <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                <asp:ListItem Value="12" Text="Dic"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlAnio" runat="server">
                                <asp:ListItem Value="0" Text="Año"></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="btnRegistrarMusico" runat="server" Text="Registrate" OnClick="btnRegistro_Click" CssClass="BotonRegistracion" ViewStateMode="Enabled" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <div id="Lugar" style="display: none;">
            <asp:Table runat="server" ID="tabRegistroLugar" CellSpacing="8">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="0" Text="Capital Federal"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Value="0" Text="Almagro"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox ID="txtCalle" runat="server" Columns="15" MaxLength="100" placeholder="Calle" CssClass="CajaTextoRegistracion"></asp:TextBox>            
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2">
                        <asp:TextBox ID="txtAltura" runat="server" Columns="5" MaxLength="10" placeholder="Altura" CssClass="CajaTextoRegistracion"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="btnRegistrarLugar" runat="server" Text="Registrate" OnClick="btnRegistro_Click" CssClass="BotonRegistracion" ViewStateMode="Enabled" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </div>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

