<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="pokedex_web.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Crea tu perfil Trainee</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" cssClass="form-control" ID="txtPassword" type="password"/>
            </div>
            <asp:Button Text="Registrarse" cssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="/">Cancelar</a>
        </div>
    </div>
</asp:Content>
