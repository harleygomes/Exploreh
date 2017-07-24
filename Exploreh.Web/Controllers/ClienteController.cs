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
using Exploreh.Business.Logradouro;
using Exploreh.Model.Logradouro;
using Exploreh.Business.Pais;
using Exploreh.Model.Cidade;
using Exploreh.Model.Uf;
using Exploreh.Model.UnidadeFederacao;

namespace Exploreh.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteBusiness _busCliente;
        private readonly PaisBusiness _busPais;
        private readonly EstadoBusiness _busEstado;
        private readonly CidadeBusiness _CidadeBusiness;
        private readonly CidadeBusiness _busCidade;
        private readonly ClienteContatoBusiness _busClienteContato;
        private readonly LogradouroBusiness _busLogradouro;

        private static bool notificacao { get; set; }


        public ClienteController()
        {
            this._busCliente = new ClienteBusiness();
            this._busPais = new PaisBusiness();
            this._busEstado = new EstadoBusiness();
            this._busCidade = new CidadeBusiness();
            this._busClienteContato = new ClienteContatoBusiness();
            this._busLogradouro = new LogradouroBusiness();
            this._CidadeBusiness = new CidadeBusiness();
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
                //Estado = _busEstado.Get().ToList()
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
                return View(model);
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
            return new JsonResult { Data = this._busCidade.Get().FirstOrDefault(c => c.DcrNome.ToLower() == cidade.ToLower()) };
        }

        [HttpPost]
        public JsonResult GetEstadoById(string uf)
        {
            return new JsonResult { Data = this._busEstado.Get().FirstOrDefault(c => c.DcrSigla.ToUpper() == uf.ToUpper()) };
        }

        [HttpPost]
        public JsonResult GetEstado(int idPais)
        {
            return new JsonResult { Data = this._busEstado.GetByPais(idPais) };
        }

        /// <summary>
        /// Cadastro de estado pela modal
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult NovoEstado(UnidadeFederacaoModel model)
        { 
             var status = _busEstado.Add(model);

            return new JsonResult { Data = status };
        }

        [HttpPost]
        public JsonResult NovaCidade(CidadeModel model)
        {
            var status = _busCidade.Add(model);

            return new JsonResult { Data = status };
        }

        [HttpPost]
        public JsonResult GetPais()
        {
            return new JsonResult { Data = this._busPais.Get() };
        }

        [HttpPost]
        public JsonResult GetClienteDashboard()
        {

            return new JsonResult { Data = _busCliente.Get().Count() };
        }

        [HttpPost]
        public JsonResult GetCep(string cep)
        {
            var logradouro = new LogradouroModel();

            if (!string.IsNullOrEmpty(cep))
                logradouro = _busLogradouro.GetCep(cep);

            return new JsonResult { Data = logradouro };
        }
    }
}
