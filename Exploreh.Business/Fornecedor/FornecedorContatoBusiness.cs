using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Fornecedor;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.FornecedorContato
{
    public class FornecedorContatoBusiness
    {
        private readonly GenericRepository<Database.FornecedorContato> _rep;


        public FornecedorContatoBusiness()
        {
            this._rep = new GenericRepository<Database.FornecedorContato>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FornecedorContatoModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<FornecedorContatoModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FornecedorContatoModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(FornecedorContatoModel model)
        {
            #region Regras

            var update = Get(model.Id);

            update.Nome = !string.IsNullOrEmpty(model.Nome) ? model.Nome : update.Nome;
            update.Email = !string.IsNullOrEmpty(model.Email) ? model.Email : update.Email;
            update.Skype = !string.IsNullOrEmpty(model.Skype) ? model.Skype : update.Skype;
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
        public bool Update(List<FornecedorContatoModel> model)
        {
            var ok = false;
            #region Regras
            foreach (var item in model)
            {
                if (item.flgDelete && item.Id > 0)
                    ok = _rep.Delete(item.Id);

                if (item.Id == 0 && !item.flgDelete)
                {
                    var c = new FornecedorContatoModel
                    {
                        Nome = item.Nome,
                        Email = item.Email,
                        Skype = item.Skype,
                        Ativo = true,
                        DataCadastro = DateTime.Now,
                        FornecedorId = item.FornecedorId
                    };

                    ok = _rep.Add(c);
                }
                else if (item.Id > 0 && !item.flgDelete)
                {

                    var update = Get(item.Id);
                    update.Nome = !string.IsNullOrEmpty(item.Nome) ? item.Nome : update.Nome;
                    update.Email = !string.IsNullOrEmpty(item.Email) ? item.Email : update.Email;
                    update.Skype = !string.IsNullOrEmpty(item.Skype) ? item.Skype : update.Skype;
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
