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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio TraineeNegocio = new TraineeNegocio();
            try
            {
                // capturar lo que el usuario ingrese en la caja de texto
                if(string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassord.Text))
                {
                    Session.Add("error", "Email o  Contraseña vacia");
                    Response.Redirect("Error.aspx");
                }

                trainee.Email = txtEmail.Text;  
                trainee.Pass = txtPassord.Text;
                if (TraineeNegocio.Login(trainee))
                {
                    /* guardamos el objeto en session para saber si el usuario esta logueado
                     * y darle acceso a las pantallas que puede ingresar segun el acceso que tenga su usuario*/
                    Session.Add("trainee", trainee);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("Error", "User o Password Incorrectos");
                    Response.Redirect("Error.aspx");
                }
            }
           // catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                Session.Add("err", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        /*
        private void Aplication_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            Session.Add("error", exc.ToString());
            Server.Transfer("Error.aspx");
        }
        */
    }
}