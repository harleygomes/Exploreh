using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploreh.Business.Perfil;
using Exploreh.Business.Usuario;
using Exploreh.Model.Helper;
using Exploreh.Model.Usuario;
using Microsoft.Ajax.Utilities;

namespace Exploreh.Web.Controllers
{
    public class CommonViewsController : Controller
    {
        private readonly UsuarioBusiness _busUsuario;
        private readonly PerfilBusiness _busPerfil;

        public CommonViewsController()
        {
            this._busUsuario = new UsuarioBusiness();    
        }

        public void ValidarNotificacao(bool notificacao)
        {
            ViewBag.Notificacao = notificacao;
        }

        public ActionResult Login()
        {
           ValidarNotificacao(true);
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel model)
        {
            var isExist = _busUsuario.Get().FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower() && u.Senha == Model.Crypt.Crypt.Base64Encode(model.Senha));
            
            if (isExist != null && isExist.Id != 0)
            {
                AutenticacaoProvider.Autenticar(isExist);
                return RedirectToAction("Index","Dashboard");
            }
            
            ValidarNotificacao(false);
            return View(model);
        }

        public ActionResult Logout()
        {
            AutenticacaoProvider.LogOut();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Error_One()
        {
            return View();
        }

        public ActionResult Error_Two()
        {
            return View();
        }

        public ActionResult LockScreen()
        {
            return View();
        }

        public ActionResult PasswordRecovery()
        {
            return View();
        }

    }
}
