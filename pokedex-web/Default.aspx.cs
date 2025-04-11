using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
namespace pokedex_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> PokemonList {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            PokemonList = negocio.ListarSP();
            if (!IsPostBack)
            {
            
                reprepetidor.DataSource = PokemonList;
                reprepetidor.DataBind();
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}