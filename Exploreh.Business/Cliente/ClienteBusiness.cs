using System;
using System.Collections.Generic;
using System.Linq;
using Exploreh.Repository.Cliente;
using Exploreh.Model.Cliente;

namespace Exploreh.Business.Cliente
{
    public class ClienteBusiness
    {
        private readonly ClienteRepository _rep = new ClienteRepository();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteModel> Get()
        {
            return _rep.Get().Where(a=>a.Ativo).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ClienteModel model)
        {
            #region Regras
            model.DataCadastro = DateTime.Now;
            model.Ativo = true;
            /*to do: model.UsuarioIdCriCliente = ?*/

            #endregion

            return _rep.Add(model);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ClienteModel model)
        {
            #region Regras

            var update = Get(model.Id);

            #endregion

            return _rep.Update(update);
        }
    }
}
