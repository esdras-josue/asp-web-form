using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;



namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Loging(Usuario usuario )
        {
			AccesoDatos accesoDatos = new AccesoDatos();	
			try
			{
				accesoDatos.setearConsulta("SELECT Id, TipoUser FROM USUARIOS WHERE Usuario = @User AND Pass = @Pass");
				accesoDatos.setearParametro("@User", usuario.User);
				accesoDatos.setearParametro("@Pass", usuario.Pass);
				accesoDatos.ejecutarLectura();

				while (accesoDatos.Lector.Read())
				{
					usuario.Id = accesoDatos.Lector["Id"].ToString();
					usuario.TipoUsuario = (int)(accesoDatos.Lector["TipoUsuario"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }

				return false;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				accesoDatos.cerrarConexion();
			}
			
        }
    }
}
