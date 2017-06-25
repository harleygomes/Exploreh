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
    public class PerfilTelaBusiness
    {
        private readonly GenericRepository<Database.PerfilTela> _rep = new GenericRepository<Database.PerfilTela>();
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(PerfilTelaModel model)
        {
            return _rep.Add(new PerfilTelaModel
            {
                Perfil_Id = model.Perfil_Id,
                Tela_Id = model.Tela_Id,
                DataCadastro = DateTime.Now
            });
        }
    }
}
