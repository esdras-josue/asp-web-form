﻿<%@ Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="pokedex_web.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Validacion{
            color:red;
            font-size: 12px;
        }
        .form-container {
            background-color: #f8f9fa;
            padding: 2rem;
            border-radius: 15px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }
        .profile-img {
            width: 100%;
            max-width: 250px;
            border-radius: 50%;
            object-fit: cover;
            border: 3px solid #dee2e6;
        }
    </style>
    <script>
        function validar() {
            // capturar el control
            const txtApellido = document.getElementById("txtApellido");
            const txtNombre = document.getElementById("txtNombre");
            if (txtApellido.value == "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                txtNombre.classList.add("is-valid");
                return false;
            }
            txtApellido.classList.remove("is-invalid");
            txtApellido.classList.add("is-valid");
            return true;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-4">Mi Perfil</h1>

    <div class="form-container">
        <div class="row">
            <!-- Formulario -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                   <%//<asp:RegularExpressionValidator ErrorMessage="email requerido" ControlToValidate="txtEmail" runat="server" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"/> %>
                        
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" ClientIDMode="Static"/>
                   <% // <asp:RequiredFieldValidator CssClass="Validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" /> %>            
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="txtApellido" MaxLength="50" />
                </div>
                <div class="mb-3">
                    <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
                </div>
                <div class="mb-3">
                    <asp:Button runat="server" Text="Guardar" CssClass="btn btn-primary" OnClientClick="return validar()" ID="btnGuardar" OnClick="btnGuardar_Click"/>
                    <a href="Default.aspx" class="btn btn-outline-secondary ms-2">Regresar</a>
                </div>
            </div>

            <!-- Imagen de perfil -->
            <div class="col-md-6 text-center">
                <div class="mb-3">
                    <label for="txtImage" class="form-label">Imagen de Perfil</label>
                    <input type="file" id="txtImage" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imgNuevoPerfil" 
                           ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                           runat="server" CssClass="img-fluid mb-3" />
            </div>
        </div>
    </div>
</asp:Content>
