using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Fornecedor;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.FornecedoresDadosBancarios
{
    public class FornecedorDadosBancariosBusiness
    {
        private readonly GenericRepository<Database.FornecedorDadosBancarios> _rep;


        public FornecedorDadosBancariosBusiness()
        {
            this._rep = new GenericRepository<Database.FornecedorDadosBancarios>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FornecedorDadosBancariosModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<FornecedorDadosBancariosModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FornecedorDadosBancariosModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(FornecedorDadosBancariosModel model)
        {
            #region Regras

            var update = Get(model.Id);

            update.Agencia = !string.IsNullOrEmpty(model.Agencia) ? model.Agencia : update.Agencia;
            update.Conta = !string.IsNullOrEmpty(model.Conta) ? model.Conta : update.Conta;
            update.Tipo = !string.IsNullOrEmpty(model.Tipo) ? model.Tipo : update.Tipo;
            update.BancoId = model.BancoId > 0 ? model.BancoId : update.BancoId;
            update.Ativo = model.Ativo;
            update.DataAlteracao = DateTime.Now;
            update.Titular = !string.IsNullOrEmpty(model.Titular) ? model.Titular : update.Titular;
            update.DocumentoTitular = !string.IsNullOrEmpty(model.DocumentoTitular) ? model.DocumentoTitular : update.DocumentoTitular;
            update.Observacoes = !string.IsNullOrEmpty(model.Observacoes) ? model.Observacoes : update.Observacoes;

            #endregion

            return _rep.Update(update);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(List<FornecedorDadosBancariosModel> model)
        {
            var ok = false;
            #region Regras
            foreach (var item in model)
            {
                if (item.flgDelete && item.Id > 0)
                    ok = _rep.Delete(item.Id);

                if (item.Id == 0 && !item.flgDelete)
                {
                    var c = new FornecedorDadosBancariosModel
                    {
                        Agencia = item.Agencia,
                        Conta = item.Conta,
                        Tipo = item.Tipo,
                        BancoId = item.BancoId,
                        Ativo = true,
                        DataCadastro = DateTime.Now,
                        FornecedorId = item.FornecedorId,
                        Titular = item.Titular,
                        DocumentoTitular = item.DocumentoTitular,
                        Observacoes = item.Observacoes
                    };

                    ok = _rep.Add(c);
                }
                else if (item.Id > 0 && !item.flgDelete)
                {

                    var update = Get(item.Id);
                    update.Agencia = !string.IsNullOrEmpty(item.Agencia) ? item.Agencia : update.Agencia;
                    update.Conta = !string.IsNullOrEmpty(item.Conta) ? item.Conta : update.Conta;
                    update.Tipo = !string.IsNullOrEmpty(item.Tipo) ? item.Tipo : update.Tipo;
                    update.BancoId = item.BancoId > 0 ? item.BancoId : update.BancoId;
                    update.Ativo = item.Ativo;
                    update.DataAlteracao = DateTime.Now;
                    update.Titular = !string.IsNullOrEmpty(item.Titular) ? item.Titular : update.Titular;
                    update.DocumentoTitular = !string.IsNullOrEmpty(item.DocumentoTitular) ? item.DocumentoTitular : update.DocumentoTitular;
                    update.Observacoes = !string.IsNullOrEmpty(item.Observacoes) ? item.Observacoes : update.Observacoes;

                    ok = _rep.Update(update);
                }
            }

            #endregion

            return ok;
        }

    }
}
