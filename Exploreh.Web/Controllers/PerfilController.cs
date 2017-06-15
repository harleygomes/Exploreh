using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploreh.Business.Perfil;
using Exploreh.Model.Perfil;

namespace Exploreh.Web.Controllers
{
    public class PerfilController : Controller
    {
        private readonly PerfilBusiness _bus = new PerfilBusiness();

        public ActionResult Lista()
        {
            return View(_bus.Get());
        }


        public ActionResult Detalhes(int id)
        {
            return View(_bus.Get(id));
        }


        public ActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Cadastrar(PerfilModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Lista");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Editar(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Editar(PerfilModel model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Lista");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Excluir(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Excluir(PerfilModel model)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Lista");
            }
            catch
            {
                return View();
            }
        }
    }
}
