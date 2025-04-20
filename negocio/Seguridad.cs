using dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public static class Seguridad
    {
        public static bool SessionActiva(Object user)
        {
            // Validar que hay un usuario logueado 
            Trainee trainee = user != null ? (Trainee)user : null;
            if (trainee != null && trainee.Id != 0) 
                return true;
            else 
                return false;
        }

        public static bool IsAdmin(Object user)
        {
            Trainee trainee = user != null ? (Trainee)user : null;
            return trainee != null ? trainee.Admin : false;
        }
    }
}
