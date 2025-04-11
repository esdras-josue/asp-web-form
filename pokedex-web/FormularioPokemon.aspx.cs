using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace pokedex_web
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public bool confirmarEliminacion {  get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false; // Deshabilita la caja de texto id del formulario
            confirmarEliminacion = false;

            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();

                    ddlTipo.DataSource = lista;
                    ddlTipo.DataValueField = "id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = lista;
                    ddlDebilidad.DataValueField = "id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();                   
                }

                // Configuracion si estamos modificanco
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    PokemonNegocio negocioPokemon = new PokemonNegocio();
                    // obteniendo lista que va devolver un solo elemento para modificar un pokemon
                    // List<Pokemon> listaPokemon = negocioPokemon.listar(id);
                    // Pokemon seleccionado = listaPokemon[0];

                    Pokemon seleccionado = negocioPokemon.listar(id)[0];

                    // guardo pokemon seleccionado en session
                    Session.Add("pokeSeleccionado", seleccionado);

                    // precargar todos los campos para modificarlo

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    txtNumero.Text = seleccionado.Numero.ToString();

                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                    // configurar acciones
                    if (!seleccionado.Activo)
                        btnDesactivar.Text = "Reactivar";
                }
            }
            catch (Exception ex) 
            {
                Session.Add("error", ex);
                throw;
            }

        }

        protected void txtUrlImage_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtImagenUrl.Text;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon newPokemon = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                newPokemon.Numero = int.Parse(txtNumero.Text);
                newPokemon.Nombre = txtNombre.Text;
                newPokemon.Descripcion = txtDescripcion.Text;
                newPokemon.UrlImagen = txtImagenUrl.Text;

                newPokemon.Tipo = new Elemento();
                newPokemon.Tipo.Id = int.Parse(ddlTipo.SelectedValue);

                newPokemon.Debilidad = new Elemento();
                newPokemon.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                negocio.agregarConSp(newPokemon);
                Response.Redirect("PokemonLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon newPokemon = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                newPokemon.Numero = int.Parse(txtNumero.Text);
                newPokemon.Nombre = txtNombre.Text;
                newPokemon.Descripcion = txtDescripcion.Text;
                newPokemon.UrlImagen = txtImagenUrl.Text;

                newPokemon.Tipo = new Elemento();
                newPokemon.Tipo.Id = int.Parse(ddlTipo.SelectedValue);

                newPokemon.Debilidad = new Elemento();
                newPokemon.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    newPokemon.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(newPokemon);
                }

                Response.Redirect("PokemonLista.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacio_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxEliminacio.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("PokemonLista.aspx");
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];
            try
            {
                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("PokemonLista.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}