using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Business.Tela;
using Exploreh.Model.Perfil;
using Exploreh.Model.Telas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exploreh.Test.Business.Tela
{
    [TestClass]
    public class TelaTest
    {
        private readonly TelaBusiness _bus = new TelaBusiness();

        [TestMethod]
        public void TestMethod_Crud_ListarTodos()
        {
            var retorno = _bus.Get();

            Assert.AreEqual(true, retorno.Count > 0);

        }

        [TestMethod]
        public void TestMethod_Crud_Cadastro()
        {
            var c = new TelasModel
            {
                Id = 0,
                Nome = "Tela I",
                Ativo = true
            };

            var retorno = _bus.Add(c);

            Assert.AreEqual(true, retorno);

        }

        [TestMethod]
        public void TestMethod_Crud_Editar()
        {
            var c = new TelasModel
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
            var c = new TelasModel
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
            var c = new TelasModel
            {
                Id = 4
            };

            var retorno = _bus.Delete(c.Id);

            Assert.AreEqual(true, retorno);
        }
    }
}
