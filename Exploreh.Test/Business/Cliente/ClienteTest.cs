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
            var lstCliente = new List<ClienteModel>()
            {
                new ClienteModel
                {
                    Id = 0,
                    Nome = "Carrefour",
                    TipoPessoa = "J",
                    Documento = "284.277.858-62",
                    Sexo = "M",
                    DataNascimento = Convert.ToDateTime("1981-08-06"),
                    Ocupacao = "Ocupacao",
                    Email = "Email",
                    HomePage = "HomePage",
                    DataCadastro = DateTime.Now,
                    Ativo = true
                },
                new ClienteModel
                {
                    Id = 0,
                    Nome = "Wall Mart",
                    TipoPessoa = "J",
                    Documento = "321.458.858-84",
                    Sexo = "M",
                    DataNascimento = Convert.ToDateTime("1987-08-09"),
                    Ocupacao = "Ocupacao",
                    Email = "Email",
                    HomePage = "HomePage",
                    DataCadastro = DateTime.Now,
                    Ativo = true
                },
                new ClienteModel
                {
                    Id = 0,
                    Nome = "Pão de Açucar",
                    TipoPessoa = "J",
                    Documento = "698.487.568-62",
                    Sexo = "M",
                    DataNascimento = Convert.ToDateTime("2000-08-06"),
                    Ocupacao = "Ocupacao",
                    Email = "Email",
                    HomePage = "HomePage",
                    DataCadastro = DateTime.Now,
                    Ativo = true
                }

            };

            bool retorno = true;
            foreach (var add in lstCliente.ToList())
            {
                var result = _bus.Add(add);
                if (!result) retorno = false;
            }

            Assert.AreEqual(true, retorno);
            
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
