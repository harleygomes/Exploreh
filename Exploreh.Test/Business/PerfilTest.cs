using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Business.Perfil;
using Exploreh.Model.Perfil;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exploreh.Test.Business
{
    [TestClass]
    public class PerfilTest
    {
        private readonly PerfilBusiness _bus = new PerfilBusiness();

        [TestMethod]
        public void TestMethod_Crud_Cadastro()
        {
            var c = new PerfilModel
            {
                Id = 0,
                Nome = "Nome II",
                Ativo = true
            };

            var retorno = _bus.Add(c);

            Assert.AreEqual(true, retorno);

        }

        [TestMethod]
        public void TestMethod_Crud_Editar()
        {
            var c = new PerfilModel
            {
                Id = 2,
                Nome = "Nome",
                Ativo = true
            };

            var retorno = _bus.Add(c);

            Assert.AreEqual(true, retorno);

        }
    }
}
