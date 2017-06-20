using System.Linq;
using System.Web.Mvc;
using Exploreh.Business.Perfil;
using Exploreh.Business.Usuario;
using Exploreh.Model.Cliente;
using Exploreh.Model.Usuario;

namespace Exploreh.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioBusiness _busUsuario;
        private readonly PerfilBusiness _busPerfil;

        public UsuarioController()
        {
            this._busUsuario = new UsuarioBusiness();
            this._busPerfil = new PerfilBusiness();
        }

        public ActionResult Lista(bool notificacao = false)
        {
            ViewBag.Notificacao = notificacao;

            return View(_busUsuario.Get().OrderBy(u => u.DataCadastro));
        }

        [HttpPost]
        public JsonResult Detalhes(int id)
        {

            var result = new JsonResult { Data = _busUsuario.Get(id) };

            return result;
        }

        public ActionResult Cadastrar()
        {
            return View(new UsuarioModel() { ddlPerfil = _busPerfil.Get() });
        }


        [HttpPost]
        public ActionResult Cadastrar(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_busUsuario.Add(model))
                        return RedirectToAction("Lista", new { notificacao = true});

                    model.ddlPerfil = _busPerfil.Get();
                    return View(model);
                }

                model.ddlPerfil = _busPerfil.Get();
                return View(model);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Editar(int id)
        {
            var model = _busUsuario.Get(id);
            model.ddlPerfil = _busPerfil.Get();

            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(_busUsuario.Update(model))
                    return RedirectToAction("Lista", new { notificacao = true });

                    model.ddlPerfil = _busPerfil.Get();
                    return View(model);
                }

                model.ddlPerfil = _busPerfil.Get();
                return View(model);
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
