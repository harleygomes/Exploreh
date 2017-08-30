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
        /// <param name="id"></param>
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

        //[HttpPost]
        //public ActionResult Editar(TelaModel model)
        //{
        //    var usuario = AutenticacaoProvider.UsuarioAutenticado;
        //    if (usuario == null)
        //    {
        //        return RedirectToAction("Login", "CommonViews");
        //    }

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var result = _bus.UpdateToReturnEntity(model);

        //            //Atribuir permissão perfil x tela
        //            if (model.PerfilModel != null)
        //            {
        //                foreach (var perfiltela in model.PerfilModel.Where(i => i.IsChecked))
        //                {
        //                    _busPerfilTelaBusiness.Update(new PerfilTelaModel
        //                    {
        //                        Perfil_Id = perfiltela.Id,
        //                        Tela_Id = result.Id
        //                    });
        //                }
        //            }

        //            if (result.Id != 0)
        //            {
        //                notificacao = true;
        //                return RedirectToAction("Lista");
        //            }

        //            return View(model);
        //        }

        //        return RedirectToAction("Lista");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //[HttpPost]
        //public JsonResult Excluir(int id)
        //{
        //    return new JsonResult { Data = _bus.Get(id) };
        //}


        //[HttpPost]
        //public ActionResult ExcluirConfirmar(TelaModel model)
        //{
        //    var usuario = AutenticacaoProvider.UsuarioAutenticado;
        //    if (usuario == null)
        //    {
        //        return RedirectToAction("Login", "CommonViews");
        //    }

        //    try
        //    {
        //        if (_bus.Delete(model.Id))
        //        {
        //            notificacao = true;
        //            return RedirectToAction("Lista");
        //        }

        //        return RedirectToAction("Lista");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
