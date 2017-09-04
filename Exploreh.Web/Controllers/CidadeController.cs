using Exploreh.Business.Cidade;
using Exploreh.Model.Cidade;
using Exploreh.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Exploreh.Web.Controllers
{
    public class CidadeController : Controller
    {
        private readonly CidadeBusiness _CidadeBusiness;
        private static bool notificacao { get; set; }

        public CidadeController()
        {
            this._CidadeBusiness = new CidadeBusiness();
        }

        public ActionResult Lista(bool? notificar, string estado = "")
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            
            ViewBag.Notificacao = notificacao;
            notificacao = false;
            
            var estadoId = 0;
            if (!string.IsNullOrEmpty(estado))
            {
                estadoId = Convert.ToInt32(estado);

                return new JsonResult { Data = _CidadeBusiness.FiltroCidadeByEstado(estadoId) };
            }

            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }


        [System.Web.Http.HttpPost]
        public ActionResult CadastrarPost(CidadeModel model)
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
                    notificacao = true;

                    return RedirectToAction("Lista", new { notificar = _CidadeBusiness.Add(model) });
                }
            }
            catch (Exception ex)
            {
                return View();
            }

            return View(model);
        }


        public ActionResult Editar(int id)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            return View(_CidadeBusiness.Get(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public ActionResult EditarPost(CidadeModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            if (_CidadeBusiness.Update(model))
                return RedirectToAction("Lista");

            return View(model);

        }

        [System.Web.Http.HttpPost]
        public JsonResult ListaFiltro(string estado = "")
        {
            var estadoId = 0;
            if (!string.IsNullOrEmpty(estado))
            {
                estadoId = Convert.ToInt32(estado);

                return new JsonResult { Data = _CidadeBusiness.FiltroCidadeByEstado(estadoId) };
            }


            return new JsonResult { Data = null };
        }

        [System.Web.Http.HttpPost]
        public JsonResult ListaFiltroNomeCidade(string estado = "", string cidade = "")
        {

            if (!string.IsNullOrEmpty(cidade) && !string.IsNullOrEmpty(estado))
            {
                var estadoId = Convert.ToInt32(estado);
                return new JsonResult { Data = _CidadeBusiness.FiltroCidadeByCidadeNome(estadoId, cidade) };
            }


            return new JsonResult { Data = null };
        }
    }
}
