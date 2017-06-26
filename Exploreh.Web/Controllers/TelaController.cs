using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploreh.Business.Tela;
using Exploreh.Model.Helper;
using Exploreh.Model.Telas;

namespace Exploreh.Web.Controllers
{
    public class TelaController : Controller
    {
        private readonly TelaBusiness _bus = new TelaBusiness();
        private static bool notificacao { get; set; }

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
        public ActionResult Cadastrar(TelaModel model)
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


                return RedirectToAction("Lista");
            }
            catch(Exception ex)
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
        public ActionResult Editar(TelaModel model)
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

                return RedirectToAction("Lista");
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
        public ActionResult ExcluirConfirmar(TelaModel model)
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

                return RedirectToAction("Lista");
            }
            catch
            {
                return View();
            }
        }
    }
}
