using Exploreh.Model.Fornecedor;
using Exploreh.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploreh.Business.Fornecedor
{
    public class FornecedorTelefoneBusiness
    {
        private readonly GenericRepository<Database.FornecedorTelefone> _rep;


        public FornecedorTelefoneBusiness()
        {
            this._rep = new GenericRepository<Database.FornecedorTelefone>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FornecedorTelefoneModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<FornecedorTelefoneModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FornecedorTelefoneModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(FornecedorTelefoneModel model)
        {
            #region Regras

            var update = Get(model.Id);

            update.Ddd = !string.IsNullOrEmpty(model.Ddd) ? model.Ddd : update.Ddd;
            update.Telefone = !string.IsNullOrEmpty(model.Telefone) ? model.Telefone : update.Telefone;
            update.Ativo = model.Ativo;
            update.DataAlteracao = DateTime.Now;
            #endregion

            return _rep.Update(update);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _rep.Delete(id);
        }

    }
}
