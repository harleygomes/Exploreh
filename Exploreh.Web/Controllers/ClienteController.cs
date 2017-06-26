using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Exploreh.Business.Cidade;
using Exploreh.Business.Cliente;
using Exploreh.Business.Estado;
using Exploreh.Model.Cliente;
using Exploreh.Model.Helper;

namespace Exploreh.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteBusiness _busCliente;
        private readonly EstadoBusiness _busEstado;
        private readonly CidadeBusiness _busCidade;

        private static bool notificacao { get; set; }


        public ClienteController()
        {
            this._busCliente = new ClienteBusiness();
            this._busEstado = new EstadoBusiness();
            this._busCidade = new CidadeBusiness();
        }

        public ActionResult Lista(bool? notificar)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            ViewBag.Notificacao = notificacao;
            notificacao = false;

            return View(_busCliente.Get());
        }


        public ActionResult Detalhes(int id)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            return View(_busCliente.Get(id));
        }


        public ActionResult Cadastrar()
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }
            
            return View(new ClienteModel
            {
                Estado = _busEstado.Get().ToList()
            });
        }


        [HttpPost]
        public ActionResult Cadastrar(ClienteModel model)
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
                    return RedirectToAction("Lista", new {notificar = _busCliente.Add(model)});
                }

                return View(model);
            }
            catch
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

            try
            {
                var model = _busCliente.Get(id);
                model.ClienteTelefone = new List<ClienteTelefoneModel> { new ClienteTelefoneModel { Ddd = "11", Telefone = "5551-98898", TipoTelefone = "F" } };
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
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            try
            {
                _busCliente.Update(model);
                return RedirectToAction("Lista");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Excluir(int id)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Excluir(ClienteModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

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

        [HttpPost]
        public JsonResult GetCidade(int id)
        {
            var result = new JsonResult { Data = this._busCidade.GetCidade(id) };
            return result;
        }
    }
}
