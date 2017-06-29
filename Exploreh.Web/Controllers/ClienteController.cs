using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Exploreh.Business.Cidade;
using Exploreh.Business.Cliente;
using Exploreh.Business.ClienteContato;
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
        private readonly ClienteContatoBusiness _busClienteContato;

        private static bool notificacao { get; set; }


        public ClienteController()
        {
            this._busCliente = new ClienteBusiness();
            this._busEstado = new EstadoBusiness();
            this._busCidade = new CidadeBusiness();
            this._busClienteContato = new ClienteContatoBusiness();
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
                    return RedirectToAction("Lista", new { notificar = _busCliente.Add(model) });
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


        [HttpPost]
        public ActionResult ExcluirConfirmar(ClienteModel model)
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
        public JsonResult Detalhes(int id)
        {
            var cliente = _busCliente.Get(id);
            cliente.ClienteContato = _busClienteContato.Get().Where(i => i.ClienteId == cliente.Id).ToList();

            return new JsonResult { Data = cliente };
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            
            return new JsonResult { Data = _busCliente.Get(id) };
        }

        [HttpPost]
        public JsonResult GetCidade(int id)
        {
            return new JsonResult { Data = this._busCidade.GetCidade(id) };
            
        }

        [HttpPost]
        public JsonResult GetCidadeByName(string cidade)
        {
            return new JsonResult { Data = this._busCidade.Get().FirstOrDefault(c => c.Nome.ToLower() == cidade.ToLower()) };
        }

        [HttpPost]
        public JsonResult GetEstadoById(string uf)
        {
            return new JsonResult { Data = this._busEstado.Get().FirstOrDefault(c => c.Sigla.ToUpper() == uf.ToUpper()) };
        }

        [HttpPost]
        public JsonResult GetClienteDashboard()
        {

            return new JsonResult { Data = _busCliente.Get().Count()};
        }
    }
}
