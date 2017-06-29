using System.Linq;
using System.Web.Mvc;
using Exploreh.Business.Perfil;
using Exploreh.Business.Usuario;
using Exploreh.Model.Cliente;
using Exploreh.Model.Helper;
using Exploreh.Model.Usuario;

namespace Exploreh.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioBusiness _busUsuario;
        private readonly PerfilBusiness _busPerfil;

        private static bool notificacao { get; set; }

        public UsuarioController()
        {
            this._busUsuario = new UsuarioBusiness();
            this._busPerfil = new PerfilBusiness();
        }

        public ActionResult Lista()
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            ViewBag.Notificacao = notificacao;
            notificacao = false;

            return View(_busUsuario.Get().OrderByDescending(u => u.DataCadastro));
        }

        [HttpPost]
        public JsonResult Detalhes(int id)
        {
            var result = _busUsuario.Get(id);
            result.NomePerfil = _busPerfil.Get(result.PerfilId).Nome;

            return new JsonResult { Data = result };
        }

        public ActionResult Cadastrar()
        {
            var usuario = AutenticacaoProvider.UsuarioAutenticado;
            if (usuario == null)
            {
                return RedirectToAction("Login", "CommonViews");
            }

            return View(new UsuarioModel() { Perfis = _busPerfil.Get() });
        }


        [HttpPost]
        public ActionResult Cadastrar(UsuarioModel model)
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
                    if (_busUsuario.Add(model))
                    {
                        notificacao = true;
                        return RedirectToAction("Lista");
                    }

                    model.Perfis = _busPerfil.Get();
                    return View(model);
                }

                model.Perfis = _busPerfil.Get();
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

            var model = _busUsuario.Get(id);
            model.Perfis = _busPerfil.Get();

            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(UsuarioModel model)
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
                    if (_busUsuario.Update(model))
                    {
                        notificacao = true;
                        return RedirectToAction("Lista");
                    }
                    model.Perfis = _busPerfil.Get();
                    return View(model);
                }

                model.Perfis = _busPerfil.Get();
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            var result = _busUsuario.Get(id);
            result.NomePerfil = _busPerfil.Get(result.PerfilId).Nome;

            return new JsonResult { Data = result };
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
                if (_busUsuario.Delete(model.Id))
                {
                    notificacao = true;
                    return RedirectToAction("Lista");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GetUsuarioExternosDashboard()
        {

            return new JsonResult { Data = _busUsuario.Get().Count(i=>i.PerfilId == 3)};
        }
    }
}
