<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pokedex_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome to Pokemon Web Site</h1>
    <p>Hellooo Pokemoms</p>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%--        <%
            foreach (dominio.Pokemon pokemon in PokemonList) // se va repetir dependiendo de la cantidad de elementos que hayan en la grilla
            {
                div class="col">
                    <div class="card h-100">
                        <img src="<%:pokemon.urlImage%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%:pokemon.Name%></h5>
                            <p class="card-text"><%:pokemon.Descripcion%></p>
                            <a href="DetallesPokemon.aspx?id=<%:pokemon.id%>">ver detalles</a>
                        </div>
                    </div>
                </div>
        %>              
           <% } %>--%>

        <asp:Repeater runat="server" ID="reprepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <a href="DetallesPokemon.aspx?id=<%#Eval("Id")%>">ver detalles</a>
                            <asp:Button Text="Ejemplo" runat="server" CssClass="btn btn-primary" id="btnEjemplo" CommandArgument='<%#Eval("Id") %>' CommanName="PokemonId" OnClick="btnEjemplo_Click"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
