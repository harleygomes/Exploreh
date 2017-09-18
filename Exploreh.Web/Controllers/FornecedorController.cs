using Exploreh.Business.Banco;
using Exploreh.Business.Cidade;
using Exploreh.Business.Estado;
using Exploreh.Business.Fornecedor;
using Exploreh.Business.FornecedorContato;
using Exploreh.Business.Logradouro;
using Exploreh.Business.Pais;
using Exploreh.Business.RamoAtividade;
using Exploreh.Model.Cidade;
using Exploreh.Model.Fornecedor;
using Exploreh.Model.Helper;
using Exploreh.Model.Logradouro;
using Exploreh.Model.UnidadeFederacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Exploreh.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly FornecedorBusiness _busFornecedor;
        private readonly PaisBusiness _busPais;
        private readonly EstadoBusiness _busEstado;
        private readonly CidadeBusiness _CidadeBusiness;
        private readonly CidadeBusiness _busCidade;
        private readonly FornecedorContatoBusiness _busFornecedorContato;
        private readonly LogradouroBusiness _busLogradouro;

        private static bool notificacao { get; set; }


        public FornecedorController()
        {
            this._busFornecedor = new FornecedorBusiness();
            this._busPais = new PaisBusiness();
            this._busEstado = new EstadoBusiness();
            this._busCidade = new CidadeBusiness();
            this._busFornecedorContato = new FornecedorContatoBusiness();
            this._busLogradouro = new LogradouroBusiness();
            this._CidadeBusiness = new CidadeBusiness();
        }

        public ActionResult Lista(bool? notificar, string Fornecedor = "")
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            ViewBag.Notificacao = notificacao;
            notificacao = false;

            return View(Fornecedor != "" ? _busFornecedor.FiltroFornecedorByName(Fornecedor) : _busFornecedor.Get());
        }


        public ActionResult Cadastrar()
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            return View(new FornecedorModel
            {
                RamosAtividade = new RamoAtividadeBusiness().Get().ToList(),
                Bancos = new BancoBusiness().Get().ToList()
               
            });
        }


        [HttpPost]
        public ActionResult Cadastrar(FornecedorModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            try
            {

                if (model.FornecedorTelefone.Any(i => i.Ddd != null && i.Telefone != null || i.DddEstrangeiro != null && i.TelefoneEstrangeiro != null))
                {
                    // Normalizando todos campos estrangeiro para um único campo esperado na tabela
                    var telefones = model.FornecedorTelefone.Where(i => i.Ddd != null && i.Telefone != null || i.DddEstrangeiro != null && i.TelefoneEstrangeiro != null).ToList();
                    model.FornecedorTelefone = new List<FornecedorTelefoneModel>();

                    foreach (var telefone in telefones)
                    {
                        if (!string.IsNullOrEmpty(telefone.DddEstrangeiro))
                            telefone.Ddd = telefone.DddEstrangeiro;

                        if (!string.IsNullOrEmpty(telefone.TelefoneEstrangeiro))
                            telefone.Telefone = telefone.TelefoneEstrangeiro;

                        model.FornecedorTelefone.Add(telefone);
                    }

                    if (ModelState.IsValid)
                    {
                        notificacao = true;
                        return RedirectToAction("Lista", new { notificar = _busFornecedor.Add(model) });
                    }

                 }

                model.RamosAtividade = new RamoAtividadeBusiness().Get().ToList();
                model.Bancos = new BancoBusiness().Get().ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                model.RamosAtividade = new RamoAtividadeBusiness().Get().ToList();
                model.Bancos = new BancoBusiness().Get().ToList();

                return View(model);
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
                var model = _busFornecedor.Get(id);
                model.RamosAtividade = new RamoAtividadeBusiness().Get().ToList();
                model.Bancos = new BancoBusiness().Get().ToList();
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }

        }


        [HttpPost]
        public ActionResult Editar(FornecedorModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            try
            {
                if(model.Id == 0)
                    return new JsonResult { Data = 0 };

                _busFornecedor.Update(model);
                return RedirectToAction("Lista");                
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult ExcluirConfirmar(FornecedorModel model)
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
            var Fornecedor = _busFornecedor.Get(id);
            Fornecedor.FornecedorContato = _busFornecedorContato.Get().Where(i => i.FornecedorId == Fornecedor.Id).ToList();

            return new JsonResult { Data = Fornecedor };
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            try
            {
                var fornecedorModel = new FornecedorModel { Id = id };
                return RedirectToAction("Lista", new { notificar = _busFornecedor.Delete(fornecedorModel) });
            }
            catch
            {
                return View();
            }
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
        public JsonResult GetFornecedorDashboard()
        {

            return new JsonResult { Data = _busFornecedor.Get().Count() };
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

