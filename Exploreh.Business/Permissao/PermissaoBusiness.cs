using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.PerfilTela;
using Exploreh.Model.Permissao;
using Exploreh.Model.Telas;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Permissao
{
    public class PermissaoBusiness
    {
        private readonly GenericRepository<Database.PerfilTela> _rep = new GenericRepository<Database.PerfilTela>();
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(PermissaoModel model)
        {
            
            return _rep.Add(new PerfilTelaModel
            {
                Perfil_Id = model.PerfilId,
                Tela_Id = model.TelaId,
                DataCadastro = DateTime.Now
            });
        }
    }
}
