using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Business.Perfil;
using Exploreh.Model.Perfil;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exploreh.Test.Business.Perfil
{
    [TestClass]
    public class PerfilTest
    {
        private readonly PerfilBusiness _bus = new PerfilBusiness();

        [TestMethod]
        public void TestMethod_Crud_ListarTodos()
        {
            var retorno = _bus.Get();

            Assert.AreEqual(true, retorno.Count > 0);

        }

        [TestMethod]
        public void TestMethod_Crud_Cadastro()
        {

            var lstPerfil = new List<PerfilModel>()
            {
                new PerfilModel()
                {
                    Id = 0,
                    Nome = "Nome I",
                    Ativo = true
                },
                new PerfilModel()
                {
                    Id = 0,
                    Nome = "Nome II",
                    Ativo = true
                },
                new PerfilModel()
                {
                    Id = 0,
                    Nome = "Nome III",
                    Ativo = true
                },
                new PerfilModel()
                {
                    Id = 0,
                    Nome = "Nome IV",
                    Ativo = true
                }

            };

            bool retorno = true;
            foreach (var add in lstPerfil)
            {
                var result = _bus.Add(add);
                if (!result) retorno = false;
            }

            Assert.AreEqual(true, retorno);

        }

        [TestMethod]
        public void TestMethod_Crud_Editar()
        {
            var c = new PerfilModel
            {
                Id = 4,
                Nome = "Externo",
                Ativo = true
            };

            var retorno = _bus.Update(c);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void TestMethod_Crud_Inativar()
        {
            var c = new PerfilModel
            {
                Id = 6,
                Ativo = false
            };

            var retorno = _bus.Update(c);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void TestMethod_Crud_Excluir()
        {
            var c = new PerfilModel
            {
                Id = 4
            };

            var retorno = _bus.Delete(c.Id);

            Assert.AreEqual(true, retorno);
        }
    }
}
