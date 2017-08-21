using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cliente;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.ClienteContato
{
    public class ClienteContatoBusiness
    {
        private readonly GenericRepository<Database.ClienteContato> _rep;


        public ClienteContatoBusiness()
        {
            this._rep = new GenericRepository<Database.ClienteContato>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteContatoModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<ClienteContatoModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteContatoModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ClienteContatoModel model)
        {
            #region Regras

            var update = Get(model.Id);

            update.Nome = !string.IsNullOrEmpty(model.Nome) ? model.Nome : update.Nome;
            update.Ativo = model.Ativo;
            update.DataAlteracao = DateTime.Now;
            #endregion

            return _rep.Update(update);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(List<ClienteContatoModel> model)
        {
            var ok = false;
            #region Regras
            foreach (var item in model)
            {
                if (item.flgDelete && item.Id > 0)
                    ok = _rep.Delete(item.Id);

                if (item.Id == 0 && !item.flgDelete)
                {
                    var c = new ClienteContatoModel
                    {
                        Nome = item.Nome,
                        Email = item.Email,
                        Ativo = true,
                        DataCadastro = DateTime.Now,
                        ClienteId = item.ClienteId
                    };

                    ok = _rep.Add(c);
                }
                else if (item.Id > 0 && !item.flgDelete)
                {

                    var update = Get(item.Id);
                    update.Nome = !string.IsNullOrEmpty(item.Nome) ? item.Nome : update.Nome;
                    update.Email = !string.IsNullOrEmpty(item.Email) ? item.Email : update.Email;
                    update.Ativo = item.Ativo;
                    update.DataAlteracao = DateTime.Now;


                    ok = _rep.Update(update);
                }
            }

            #endregion

            return ok;
        }

    }
}
