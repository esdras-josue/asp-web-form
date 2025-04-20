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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.SessionActiva(Session["trainee"]))
                    {
                        Trainee user = (Trainee)Session["trainee"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");

                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            TraineeNegocio negocio = new TraineeNegocio();
            Trainee user = (Trainee)Session["trainee"];
            try
            {
                // guardar imagen
                if(txtImage.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");   // obtener ruta donde guardamos las imagenes
                    txtImage.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg"); // guardamos la imagen con el nombre 'perfil' + el numero de ID de usuario en session
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg"; // guardar imagen en base de datos el nombre de la foto con el ID
                }
                
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                
                
                negocio.Actualizar(user);
                // agregagando imagen al perfil
               Image img = (Image)Master.FindControl("imgAvatar");
               img.ImageUrl = "~/Images/" + user.ImagenPerfil;
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }
    }
}