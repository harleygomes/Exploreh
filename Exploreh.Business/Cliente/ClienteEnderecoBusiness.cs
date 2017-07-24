using Exploreh.Model.Cliente;
using Exploreh.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploreh.Business.Cliente
{
    public class ClienteEnderecoBusiness
    {
        private readonly GenericRepository<Database.ClienteEndereco> _rep;


        public ClienteEnderecoBusiness()
        {
            this._rep = new GenericRepository<Database.ClienteEndereco>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteEnderecoModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<ClienteEnderecoModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteEnderecoModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ClienteEnderecoModel model)
        {
            #region Regras

            var update = Get(model.Id);
            update.Logradouro = !string.IsNullOrEmpty(model.Logradouro)? model.Logradouro:update.Logradouro;
            update.Numero = !string.IsNullOrEmpty(model.Numero) ? model.Numero : update.Numero;
            update.Bairro = !string.IsNullOrEmpty(model.Bairro) ? model.Bairro : update.Bairro;
            update.Complemento = !string.IsNullOrEmpty(model.Complemento) ? model.Complemento : update.Complemento;
            update.CEP = !string.IsNullOrEmpty(model.CEP) ? model.CEP : update.CEP;
            update.IdCidade = model.IdCidade > 0? model.IdCidade: update.IdCidade;
            update.DataCadastro = update.DataCadastro;
            update.DataAlteracao = DateTime.Now;
            update.Ativo = update.Ativo;

            #endregion

            return _rep.Update(update);
        }

    }
}
