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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                EmailService emailService = new EmailService();
                // cargamos los datos del fomulario
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Id = traineeNegocio.InsertarNuevo(user);
                Session.Add("trainee", user);

                emailService.armarCorreo(user.Email, "Hola trainer", "te damos la Bienvenida a la aplicacion");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fallo del envio del correo" + ex.Message);
                //Session.Add("error", ex.ToString());
            }
        }
    }
}