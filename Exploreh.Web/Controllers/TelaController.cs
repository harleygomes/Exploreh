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

namespace Exploreh.Web.Controllers
{
    public class TelaController : Controller
    {

        #region Instâncias

        private readonly TelaBusiness _bus;
        private readonly PerfilBusiness _busperfil;
        private readonly PerfilTelaBusiness _busPerfilTelaBusiness;
        #endregion

        public TelaController()
        {
            this._bus = new TelaBusiness();
            this._busperfil = new PerfilBusiness();
            this._busPerfilTelaBusiness = new PerfilTelaBusiness();
        }

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


            return View(new TelaModel { PerfilModel = _busperfil.Get().Where(i => i.Ativo).ToList() });
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
                    var result = _bus.AddToReturnEntity(model);
                   
                    //Atribuir permissão perfil x tela
                    if (model.PerfilModel != null)
                    {
                        foreach (var perfiltela in model.PerfilModel.Where(i=>i.IsChecked))
                        {
                            _busPerfilTelaBusiness.Add(new PerfilTelaModel
                            {
                                Perfil_Id = perfiltela.Id,
                                Tela_Id = result.Id
                            });
                        }
                    }

                    if (result.Id != 0)
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
                    var result = _bus.UpdateToReturnEntity(model);

                    //Atribuir permissão perfil x tela
                    if (model.PerfilModel != null)
                    {
                        foreach (var perfiltela in model.PerfilModel.Where(i => i.IsChecked))
                        {
                            _busPerfilTelaBusiness.Update(new PerfilTelaModel
                            {
                                Perfil_Id = perfiltela.Id,
                                Tela_Id = result.Id
                            });
                        }
                    }

                    if (result.Id != 0)
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
