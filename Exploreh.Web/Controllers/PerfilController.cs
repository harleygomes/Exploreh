using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploreh.Business.Perfil;
using Exploreh.Model.Helper;
using Exploreh.Model.Perfil;

namespace Exploreh.Web.Controllers
{
    public class PerfilController : Controller
    {
        private readonly PerfilBusiness _bus;
        private static bool notificacao { get; set; }

        public PerfilController()
        {
            this._bus = new PerfilBusiness();
        }

        public ActionResult Lista()
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            ViewBag.Notificacao = notificacao;
            notificacao = false;

            return View(_bus.Get().OrderByDescending(p => p.DataCadastro));
        }

        [HttpPost]
        public JsonResult Detalhes(int id)
        {
            return new JsonResult { Data = _bus.Get(id) };
        }


        public ActionResult Cadastrar()
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Cadastrar(PerfilModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (_bus.Add(model))
                    {
                        notificacao = true;
                        return RedirectToAction("Lista");
                    }
                    
                    return View(model);
                }
                
                return View(model);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Editar(int id)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            return View(_bus.Get(id));
        }


        [HttpPost]
        public ActionResult Editar(PerfilModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (_bus.Update(model))
                    {
                        notificacao = true;
                        return RedirectToAction("Lista");
                    }
                    
                    return View(model);
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public JsonResult Excluir(int id)
        {
            return new JsonResult { Data = _bus.Get(id) };
        }


        [HttpPost]
        public ActionResult ExcluirConfirmar(PerfilModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            try
            {
                if (_bus.Delete(model.Id))
                {
                    notificacao = true;
                    return RedirectToAction("Lista");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
