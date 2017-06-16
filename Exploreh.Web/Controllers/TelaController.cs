using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploreh.Business.Tela;
using Exploreh.Model.Telas;

namespace Exploreh.Web.Controllers
{
    public class TelaController : Controller
    {
        private readonly TelaBusiness _bus = new TelaBusiness();

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
        public ActionResult Cadastrar(TelaModel model)
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
        public ActionResult Editar(TelaModel model)
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
        public ActionResult Excluir(TelaModel model)
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
