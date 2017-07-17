using System;
using System.Collections.Generic;
using System.Linq;
using Exploreh.Model.Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exploreh.Business.Cliente;

namespace Exploreh.Test.Business.Cliente
{
    [TestClass]
    public class AreaTest
    {
        private readonly ClienteBusiness _bus = new ClienteBusiness();

        [TestMethod]
        public void TestMethod_Crud_Cadastro()
        {
            var c = new ClienteModel
            {
                Id = 0,
                Nome = "Nome",
                TipoPessoa = "F",
                Documento = "284.277.858-62",
                Sexo = "M",
                DataNascimento = Convert.ToDateTime("1981-08-06"),
                Ocupacao = "Ocupacao",
                Email = "Email",
                HomePage = "HomePage",
                DataCadastro = DateTime.Now,
                Ativo = true
            };

            c.ClienteEndereco = new List<ClienteEnderecoModel> { new ClienteEnderecoModel
                {
                    Logradouro = "Mateus Serrao",
                    Numero = "30",
                    Complemento = "Sem COmplemento",
                    CEP = "04914-080",
                    Bairro = "Jd. Klein",
                    IdCidade = 1,
                    ClienteId = c.Id,
                    DataCadastro = DateTime.Now,
                    Ativo = true
                } };

            c.ClienteTelefone = new List<ClienteTelefoneModel> { new ClienteTelefoneModel
            {
                ClienteId = c.Id,
                Ddd = "11",
                Telefone="5514-6203",
                TipoTelefone = "F",
                DataCadastro= DateTime.Now,
                Ativo= true
            } };

            var result = _bus.Add(c);

            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void TestMethod_Crud_Edicao()
        {
            //var Area = new AreaModel
            //{
            //    Id = 3,
            //    Nome = "Marketing",
            //    Descricao = "ALT Ipsum Operacao Dolor Ahubn as Loren Ipsum Operacao Dolor Ahubn asLoren Ipsum Operacao Dolor Ahubn as",
            //    UsuarioIdEdicao = 1,
            //    Ativo = true
            //};

            //var retorno = _bus.Update(Area);

            //Assert.AreEqual(true, retorno);

        }

        [TestMethod]
        public void TestMethod_Crud_Deletar()
        {
            //var Area = new AreaModel
            //{
            //    Id = 3,
            //    Ativo = false
            //};

            //var retorno = _bus.Update(Area);

            //Assert.AreEqual(true, retorno);

        }

        [TestMethod]
        public void TestMethod_Crud_Listar()
        {
            //var retorno = _bus.Get();

            //Assert.AreEqual(true, retorno != null);

        }
    }
}
