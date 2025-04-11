<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="pokedex_web.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNumero" class="form-label">Numero:</label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo:</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server" />
            </div>

            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" />
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" />
                <asp:Button runat="server" CssClass="btn btn-danger" Text="Desactivar" ID="btnDesactivar" OnClick="btnDesactivar_Click" />
                <a href="Default.aspx" class="btn btn-warning">Cancelar</a>
            </div>

            <div class="mb-3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button runat="server" CssClass="btn btn-danger" Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" />
                        <% if (confirmarEliminacion)
                            { %>
                        <asp:Button runat="server" CssClass="btn btn-outline-danger" Text="Eliminar" ID="btnConfirmarEliminacio" OnClick="btnConfirmarEliminacio_Click"/>
                        <asp:CheckBox runat="server" Text="Confirmar Eliminacion" ID="CheckBoxEliminacio" />
                        <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Image
                        ImageUrl="https://th.bing.com/th/id/OIP.v3_2lDKLaxi3QIOKETrd0wHaEK?w=267&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                        runat="server" ID="imgPokemon" Width="50%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
