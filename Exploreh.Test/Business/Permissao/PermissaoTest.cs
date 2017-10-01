using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Business.Perfil;
using Exploreh.Business.PerfilTela;
using Exploreh.Business.Tela;
using Exploreh.Model.Perfil;
using Exploreh.Model.Permissao;
using Exploreh.Model.Telas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exploreh.Test.Business.Permissao
{
    [TestClass]
    public class PermissaoTest
    {
        
        private readonly TelaBusiness _busTela = new TelaBusiness();
        private readonly PerfilBusiness _busPerfil = new PerfilBusiness();
        private readonly PerfilTelaBusiness _busPerfilTela = new PerfilTelaBusiness();

        [TestMethod]
        public void TestMethod_Crud_ListarTodos()
        {
            #region Join 

            var telaModel = _busTela.Get().ToList().ConvertAll<TelaModel>(x => x);

            foreach (var tela in telaModel.ToList())
            {
                tela.PerfilModel = new List<PerfilModel>();

                foreach (var perfil in tela.PerfilTelaModel.ToList())
                {
                    var perfilModel = _busPerfil.Get(perfil.Perfil_Id);

                    tela.PerfilModel.Add(new PerfilModel
                    {
                        Id = perfilModel.Id,
                        Nome = perfilModel.Nome
                    });
                }
                
            }
            

            #endregion

            //var resultTelaspermissao = model;

            //Assert.AreEqual(true, retorno.Count > 0);

        }
        
    }
}
