using System;
using System.Collections.Generic;
using System.Linq;
using Exploreh.Model.Cliente;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.Cliente
{
    public class ClienteBusiness
    {
        /*
        * O tipo da entidade é passado nessa instância(GenericRepository<>), o respositório esta prototipado para atender ao CRUD
        * assim que dissermos o tipo de entidade no GenericRepository<> o implicit operator entrará em ação.
        * 
        * OBS: A idéia é daqui pra baixo não escrevermos mais nada!
        * 
        * Não precisa agradecer :)
        */
        private readonly GenericRepository<Database.Cliente> _rep = new GenericRepository<Database.Cliente>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteModel> Get()
        {
            return _rep.Get().Where(a=>a.Ativo).ToList().ConvertAll<ClienteModel>(x => x);
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
