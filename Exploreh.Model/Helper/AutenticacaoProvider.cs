using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Exploreh.Model.Usuario;

namespace Exploreh.Model.Helper
{
    public class AutenticacaoProvider
    {
        public static bool Autenticar(UsuarioModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Senha)) return false;


            HttpContext.Current.Session["Usuario"] = new UsuarioModel
            {
                Id = model.Id,
                Nome = model.Nome,
                Email = model.Email,
                PerfilId = model.PerfilId

            };

            return true;
        }

        public static void LogOut()
        {
            HttpContext.Current.Session.Remove("Usuario");
        }

        public static bool Autenticado
        {
            get
            {
                return HttpContext.Current.Session["Usuario"] != null && HttpContext.Current.Session["Usuario"].GetType() == typeof(UsuarioModel);
            }
        }

        public static UsuarioModel UsuarioAutenticado
        {
            get
            {
                if (Autenticado)
                    return (UsuarioModel)HttpContext.Current.Session["Usuario"];
                return null;

            }
        }
    }
}
