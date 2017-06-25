using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploreh.Business.Perfil;
using Exploreh.Business.Permissao;
using Exploreh.Business.Tela;
using Exploreh.Model.Permissao;

namespace Exploreh.Web.Controllers
{
    public class PermissaoController : Controller
    {

        private readonly TelaBusiness _busTela;
        private readonly PerfilBusiness _busPerfil;
        private readonly PermissaoBusiness _busPermissao;

        public PermissaoController()
        {
            this._busTela = new TelaBusiness();
            this._busPerfil = new PerfilBusiness();
            this._busPermissao = new PermissaoBusiness();
        }

        public ActionResult Lista()
        {
            var model = new PermissaoModel
            {
                Tela = _busTela.Get().Where(i => i.PerfilModel.Any(pm => pm.Perfil_Id == i.Id)).OrderByDescending(d => d.DataCadastro).ToList()
            };


            return View(model);
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }

      
        public ActionResult Cadastrar()
        {
            return View(new PermissaoModel
            {
                Tela = _busTela.Get().Where(i => i.Ativo).OrderByDescending(d => d.DataCadastro).ToList(),
                Perfil = _busPerfil.Get().Where(i=>i.Ativo).OrderByDescending(d => d.DataCadastro).ToList()
            });
        }

       
        [HttpPost]
        public ActionResult Cadastrar(PermissaoModel model)
        {
            try
            {
                model.Perfil = _busPerfil.Get().Where(i => i.Id == model.PerfilId).ToList();
                this._busPermissao.Add(model);

                return RedirectToAction("Lista");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
