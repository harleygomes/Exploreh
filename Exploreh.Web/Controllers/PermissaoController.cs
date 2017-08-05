using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploreh.Business.Perfil;
using Exploreh.Business.Tela;
using Exploreh.Model.Permissao;
using Exploreh.Business.PerfilTela;
using Exploreh.Model.Helper;
using Exploreh.Model.Perfil;
using Exploreh.Model.PerfilTela;
using Exploreh.Model.Telas;

namespace Exploreh.Web.Controllers
{
    public class PermissaoController : Controller
    {

        private readonly TelaBusiness _busTela;
        private readonly PerfilBusiness _busPerfil;
        private readonly PerfilTelaBusiness _busPerfilTela;
        private static bool notificacao { get; set; }

        public PermissaoController()
        {
            this._busTela = new TelaBusiness();
            this._busPerfil = new PerfilBusiness();
            this._busPerfilTela = new PerfilTelaBusiness();

        }

        public ActionResult Lista(string perm = "")
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            ViewBag.Notificacao = notificacao;
            notificacao = false;

            #region Join 
            var telasPermissao = _busTela.Get()
                .Join(
                    _busPerfilTela.Get(),
                    tela => tela.Id,
                    perfilTela => perfilTela.Tela_Id,
                    (tela, perfilTela) => new { tela, perfilTela }
                )
                .Join(
                    _busPerfil.Get(),
                    perfilTela => perfilTela.perfilTela.Perfil_Id,
                    perfil => perfil.Id,
                    (perfilTela, perfil) => new
                    {
                        Id = perfilTela.perfilTela.Id,
                        Tela = perfilTela.tela.Nome,
                        Ativo = perfilTela.tela.Ativo,
                        Descricao = perfilTela.tela.Descricao,
                        //Perfil = perfil.Nome
                        PerfilId = perfil.Id
                    }
                ).Where(tela => tela.Ativo).ToList();

            var model = new List<PermissaoModel>();

            #region Comment
            //foreach (var permissao in telasPermissao)
            //{
            //    model.Add(new PermissaoModel
            //    {
            //        Id = permissao.Id,
            //        Ativo = permissao.Ativo,
            //        Perfil = permissao.Perfil,
            //        Descricao = permissao.Descricao,
            //        Tela = permissao.Tela
            //    });
            //}
            #endregion

            foreach (var permissao in telasPermissao)
            {
                var perfiltela = _busPerfilTela.Get().Where(i => i.Perfil_Id == permissao.PerfilId).ToList();

                foreach (var itemPerfil in perfiltela)
                {
                    var permi = new PermissaoModel
                    {
                        Id = permissao.Id,
                        Nome = permissao.Tela,
                        PerfilId = permissao.PerfilId,
                        Perfis = _busPerfil.Get().Where(i => i.Id == itemPerfil.Perfil_Id).Select(n => new PerfilModel() { Id = n.Id, Nome = n.Nome }).ToList()
                    };

                    model.Add(permi);
                }
                
            }
            #endregion

          
             //return View(model.OrderByDescending(i => i.Nome));
            return View(perm != "" ? model.OrderByDescending(i=>i.Nome).Where(x=>x.Nome.Contains(perm)) : model.OrderByDescending(i => i.Nome));
        }

        [HttpPost]
        public JsonResult Detalhes(int id)
        {
            return new JsonResult { Data = ResultJoin(id) };

        }


        public ActionResult Cadastrar()
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            return View(new PerfilTelaModel
            {
                Tela = _busTela.Get().Where(i => i.Ativo).OrderByDescending(d => d.DataCadastro).ToList(),
                Perfil = _busPerfil.Get().Where(i => i.Ativo).OrderByDescending(d => d.DataCadastro).ToList()
            });
        }


        [HttpPost]
        public ActionResult Cadastrar(PerfilTelaModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            try
            {
                var isExist = this._busPerfilTela.Get().Any(i => i.Perfil_Id == model.Perfil_Id && i.Tela_Id == model.Tela_Id);
                if (model.Id == 0 && !isExist)
                {
                    notificacao = true;
                    this._busPerfilTela.Add(model);
                    return RedirectToAction("Lista");
                }

                if (model.Id == 0 && isExist)
                {
                    notificacao = true;
                    return RedirectToAction("Lista");
                }

                this._busPerfilTela.Update(model);
                return View(model);

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

            var model = _busPerfilTela.Get(id);
            model.Tela = _busTela.Get().Where(i => i.Ativo).OrderByDescending(d => d.DataCadastro).ToList();
            model.Perfil = _busPerfil.Get().Where(i => i.Ativo).OrderByDescending(d => d.DataCadastro).ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(PerfilTelaModel model)
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
                    if (_busPerfilTela.Update(model))
                    {
                        notificacao = true;
                        return RedirectToAction("Lista");
                    }
                    else
                    {
                        model.Tela = _busTela.Get().Where(i => i.Ativo).OrderByDescending(d => d.DataCadastro).ToList();
                        model.Perfil = _busPerfil.Get().Where(i => i.Ativo).OrderByDescending(d => d.DataCadastro).ToList();
                        return View(model);
                    }

                }

                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public JsonResult Excluir(int id)
        {
            return new JsonResult { Data = ResultJoin(id) };
        }


        [HttpPost]
        public ActionResult ExcluirConfirmar(PerfilTelaModel model)
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            try
            {
                if (_busPerfilTela.Delete(model.Id))
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

        public PermissaoModel ResultJoin(int id)
        {

            #region Join 
            var telasPermissao = _busTela.Get()
                .Join(
                    _busPerfilTela.Get(),
                    tela => tela.Id,
                    perfilTela => perfilTela.Tela_Id,
                    (tela, perfilTela) => new { tela, perfilTela }
                )
                .Join(
                    _busPerfil.Get(),
                    perfilTela => perfilTela.perfilTela.Perfil_Id,
                    perfil => perfil.Id,
                    (perfilTela, perfil) => new
                    {
                        Id = perfilTela.perfilTela.Id,
                        Tela = perfilTela.tela.Nome,
                        Ativo = perfilTela.tela.Ativo,
                        Descricao = perfilTela.tela.Descricao,
                        Perfil = perfil.Nome
                    }
                ).FirstOrDefault(tela => tela.Id == id);

            var model = new PermissaoModel();
            if (telasPermissao != null)
            {
                //model.Id = telasPermissao.Id;
                //model.Ativo = telasPermissao.Ativo;
                //model.Perfil = telasPermissao.Perfil;
                //model.Descricao = telasPermissao.Descricao;
                //model.Tela = telasPermissao.Tela;

            }
            #endregion

            return model;
        }

    }
}
