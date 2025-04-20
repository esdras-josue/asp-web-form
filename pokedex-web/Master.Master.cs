using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedex_web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            // Validar sesión solo si no es Login, Default, Registro o Error
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
            {
                if (!Seguridad.SessionActiva(Session["trainee"])) // validar session para las demas paginas
                 Response.Redirect("Login.aspx", false);
            }

            if (Seguridad.SessionActiva(Session["trainee"]))
            {
                Trainee user = (Trainee)Session["trainee"];
                lblUser.Text = user.Email;
                if(!string.IsNullOrEmpty(user.ImagenPerfil))
                imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
            }   
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}