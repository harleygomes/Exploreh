using Exploreh.Model.Cliente;
using Exploreh.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploreh.Business.Cliente
{
    public class ClienteTelefoneBusiness
    {
        private readonly GenericRepository<Database.ClienteTelefone> _rep;


        public ClienteTelefoneBusiness()
        {
            this._rep = new GenericRepository<Database.ClienteTelefone>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteTelefoneModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<ClienteTelefoneModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteTelefoneModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ClienteTelefoneModel model)
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
