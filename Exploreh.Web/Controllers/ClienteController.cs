using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploreh.Business.Cliente;
using Exploreh.Model.Cliente;

namespace Exploreh.Web.Controllers
{
    public class ClienteController : Controller
    {
       private readonly ClienteBusiness _bus = new ClienteBusiness();

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
        public ActionResult Cadastrar(ClienteModel model)
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
        public ActionResult Editar(ClienteModel model)
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
        public ActionResult Excluir(ClienteModel model)
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
