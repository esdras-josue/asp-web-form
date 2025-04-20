<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pokedex_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <div class="mb3">
                <h1>Login</h1>
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" cssClass="form-control" Type="password" ID="txtPassord" />
            </div>
            <div class="mb-3">
                <asp:Button runat="server" Text="Login" cssClass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" />
                <a href="/">Cancelar</a>
            </div>
            <div class="mb-3">
                <p>¿No tienes una cuenta? <a href="Registro.aspx" class="btn btn-outline-primary">Regístrate Aqui</a></p>
            </div>
        </div>
    </div>
</asp:Content>
