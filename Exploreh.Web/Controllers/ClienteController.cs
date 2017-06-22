using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Exploreh.Business.Cliente;
using Exploreh.Model.Cliente;

namespace Exploreh.Web.Controllers
{
    public class ClienteController : Controller
    {
       private readonly ClienteBusiness _bus = new ClienteBusiness();

        public ActionResult Lista(bool? notificar)
        {
            ViewBag.Notificacao = notificar;
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
                return RedirectToAction("Lista", new {notificar = _bus.Add(model)});
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Editar(int id)
        {
            try
            {
                var model = _bus.Get(id);
                model.ClienteTelefone = new List<ClienteTelefoneModel> {new ClienteTelefoneModel {Ddd = "11",Telefone = "5551-98898",TipoTelefone = "F"} };
                return View(model);
            }
            catch
            {
                return View();
            }
            
        }


        [HttpPost]
        public ActionResult Editar(ClienteModel model)
        {
            try
            {
                _bus.Update(model);
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
