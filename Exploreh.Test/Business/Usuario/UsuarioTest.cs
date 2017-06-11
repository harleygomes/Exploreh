using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Business.Usuario;
using Exploreh.Model.Perfil;
using Exploreh.Model.Usuario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exploreh.Test.Business.Usuario
{
    [TestClass]
    public class UsuarioTest
    {
        private readonly UsuarioBusiness _bus = new UsuarioBusiness();

        [TestMethod]
        public void TestMethod_Crud_ListarTodos()
        {
            var retorno = _bus.Get();

            Assert.AreEqual(true, retorno.Count > 0);

        }

        [TestMethod]
        public void TestMethod_Crud_Cadastro()
        {

            var lstUsuario = new List<UsuarioModel>()
            {
                new UsuarioModel
                {
                    Nome = "Jose Pederneiras",
                    Email = "josepederneiras@gmail.com",
                    Senha = "123456",
                    PerfilId = 1
                },
                new UsuarioModel()
                {
                    Nome = "Eder Carlos da Costa",
                    Email = "edercarlosdacosta@gmail.com",
                    Senha = "1234567",
                    PerfilId = 1
                },
                new UsuarioModel()
                {
                    Nome = "João Dória",
                    Email = "joaodoriaprapresidente@gmail.com",
                    Senha = "12345678",
                    PerfilId = 2
                },
                new UsuarioModel()
                {
                    Nome = "Pablo Picasso",
                    Email = "pablitopricasso@gmail.com",
                    Senha = "123456789",
                    PerfilId = 3
                }

            };

            bool retorno = true;
            foreach (var add in lstUsuario)
            {
                var result = _bus.Add(add);
                if (!result) retorno = false;
            }

            Assert.AreEqual(true, retorno);

        }

        [TestMethod]
        public void TestMethod_Crud_Editar()
        {
            var c = new UsuarioModel
            {
                Id = 2,
                Nome = "Nome II (Editado)",
                Ativo = true,
                PerfilId = 2
            };

            var retorno = _bus.Update(c);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void TestMethod_Crud_Inativar()
        {
            var c = new UsuarioModel
            {
                Id = 3,
                Ativo = false
            };

            var retorno = _bus.Update(c);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void TestMethod_Crud_Excluir()
        {
            var c = new UsuarioModel
            {
                Id = 3
            };

            var retorno = _bus.Delete(c.Id);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void TestMethod_Crud_Login()
        {
            var existe = _bus.Get(1);

            Assert.AreEqual(true, existe != null);
        }
    }
}
