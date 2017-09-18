using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploreh.Business.Perfil;
using Exploreh.Business.PerfilTela;
using Exploreh.Business.Tela;
using Exploreh.Model.Helper;
using Exploreh.Model.Perfil;
using Exploreh.Model.PerfilTela;
using Exploreh.Model.Telas;
using Exploreh.Business.Pais;
using Exploreh.Model.UnidadeFederacao;

namespace Exploreh.Web.Controllers
{
    public class EstadoController : Controller
    {

        #region Instâncias

        private readonly Business.Estado.EstadoBusiness _bus;
        #endregion

        public EstadoController()
        {
            this._bus = new Business.Estado.EstadoBusiness();
        }

        private static bool notificacao { get; set; }

        public ActionResult Lista(string DcrNome = "")
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            ViewBag.Notificacao = notificacao;
            notificacao = false;
                        
            if(DcrNome != "")
                return View(_bus.FiltroEstadoByName(DcrNome));

            return View(_bus.Get());
        }

        //[HttpPost]
        //public JsonResult Detalhes(int id)
        //{
        //    return new JsonResult { Data = _bus.Get(id) };
        //}

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
        public ActionResult Cadastrar(UnidadeFederacaoModel model)
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
                    var result = _bus.Add(model);

                    if (result)
                    {
                        notificacao = true;
                        return RedirectToAction("Lista");
                    }

                    return View(model);
                }


                return RedirectToAction("Lista");
            }
            catch (Exception ex)
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

       /// <summary>
       /// 
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(UnidadeFederacaoModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            if(_bus.Update(model))
                return RedirectToAction("Lista");

            return View(model);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(string IdUnidadeFederacao)
        {
            var model = new UnidadeFederacaoModel();
            if (!string.IsNullOrEmpty(IdUnidadeFederacao))
            {
                model.IdUnidadeFederacao = Convert.ToInt32(IdUnidadeFederacao);
                return new JsonResult { Data = _bus.Delete(model) };
            }

            return new JsonResult { Data = false };
        }


        [System.Web.Http.HttpPost]
        public JsonResult ListaFiltro(string pais = "")
        {
            var paisId = 0;
            if (!string.IsNullOrEmpty(pais))
            {
                paisId = Convert.ToInt32(pais);

                return new JsonResult { Data = _bus.FiltroByEstado(paisId) };
            }


            return new JsonResult { Data = null };
        }

        [System.Web.Http.HttpPost]
        public JsonResult ListaFiltroNome(string estado = "")
        {

            if (!string.IsNullOrEmpty(estado))
            {          
                return new JsonResult { Data = _bus.FiltroCidadeByNome(estado) };
            }


            return new JsonResult { Data = null };
        }
    }
}
