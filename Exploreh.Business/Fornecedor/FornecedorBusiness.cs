using System;
using System.Collections.Generic;
using System.Linq;
using Exploreh.Model.Fornecedor;
using Exploreh.Repository.Repository;
using Exploreh.Business.Estado;

namespace Exploreh.Business.Fornecedor
{
    public class FornecedorBusiness
    {
        /*
        * O tipo da entidade é passado nessa instância(GenericRepository<>), o respositório esta prototipado para atender ao CRUD
        * assim que dissermos o tipo de entidade no GenericRepository<> o implicit operator entrará em ação.
        * 
        * OBS: A idéia é daqui pra baixo não escrevermos mais nada!
        * 
        * Não precisa agradecer :)
        */
        private readonly GenericRepository<Database.Fornecedor> _rep = new GenericRepository<Database.Fornecedor>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FornecedorModel> Get()
        {
            return _rep.Get().Where(a => a.Ativo).ToList().ConvertAll<FornecedorModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FornecedorModel> GetCep()
        {
            return _rep.Get().Where(a => a.Ativo).ToList().ConvertAll<FornecedorModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FornecedorModel Get(int id)
        {
            FornecedorModel Fornecedor = _rep.Get(id);
            foreach (var FornecedorEndereco in Fornecedor.FornecedorEndereco)
            {
                FornecedorEndereco.IdEstado = (int)new Cidade.CidadeBusiness().Get((int)FornecedorEndereco.IdCidade).IdUnidadeFederacao;
                FornecedorEndereco.IdPais = (int)new Estado.EstadoBusiness().Get((int)FornecedorEndereco.IdEstado).IdPais;
            }

            return Fornecedor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(FornecedorModel model)
        {
            #region Regras
            model.DataCadastro = DateTime.Now;
            model.Ativo = true;
            model.FornecedorTelefone.ToList().ForEach(t =>
            {
                t.DataCadastro = DateTime.Now;
                t.Ativo = true;
                if (string.IsNullOrEmpty(t.Ddd) && string.IsNullOrEmpty(t.TipoTelefone) &&
                    string.IsNullOrEmpty(t.Telefone))
                {
                    model.FornecedorTelefone.Remove(t);
                }
            });
            model.FornecedorEndereco.ToList().ForEach(t =>
            {
                t.DataCadastro = DateTime.Now;
                t.Ativo = true;
            });
            var contatos = new List<FornecedorContatoModel>();

            if (model.ContatoNome != null)
            {

                for (int i = 0; i < model.ContatoNome.Length; i++)
                {
                    if (string.IsNullOrEmpty(model.ContatoFlgDelete[i]))
                        model.ContatoFlgDelete[i] = "false";

                    if (!string.IsNullOrEmpty(model.ContatoNome[i]) && !string.IsNullOrEmpty(model.ContatoEmail[i]) && Convert.ToBoolean(model.ContatoFlgDelete[i]) == false)
                    {
                        FornecedorContatoModel c = new FornecedorContatoModel
                        {
                            Nome = model.ContatoNome[i],
                            Email = model.ContatoEmail[i],
                            Skype = model.ContatoSkype[i],
                            Ativo = true,
                            DataCadastro = DateTime.Now
                        };
                        contatos.Add(c);
                    }
                }
            }
            model.FornecedorContato = contatos;

            var dadosBancarios = new List<FornecedorDadosBancariosModel>();

            if (model.Conta != null)
            {
                for (int i = 0; i < model.Conta.Length; i++)
                {
                    if (string.IsNullOrEmpty(model.ContaFlgDelete[i]))
                        model.ContaFlgDelete[i] = "false";

                    if (!string.IsNullOrEmpty(model.Conta[i]) && !string.IsNullOrEmpty(model.Agencia[i]) && Convert.ToBoolean(model.ContaFlgDelete[i]) == false)
                    {
                        FornecedorDadosBancariosModel c = new FornecedorDadosBancariosModel
                        {
                            Agencia = model.Agencia[i],
                            Conta = model.Conta[i],
                            BancoId = Convert.ToInt16(model.BancoId[i]),
                            Tipo = model.TipoConta[i],
                            Ativo = true,
                            DataCadastro = DateTime.Now
                        };
                        dadosBancarios.Add(c);
                    }
                }
            }
            model.FornecedorDadosBancarios = dadosBancarios;

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
        public bool Update(FornecedorModel model)
        {
            #region Regras
            var update = Get(model.Id);
            update.RazaoSocial = !string.IsNullOrEmpty(model.RazaoSocial) ? model.RazaoSocial : update.RazaoSocial;
            update.NomeFantasia = !string.IsNullOrEmpty(model.NomeFantasia) ? model.NomeFantasia : update.NomeFantasia;
            update.Documento = !string.IsNullOrEmpty(model.Documento) ? model.Documento : update.Documento;
            update.RazaoSocial = !string.IsNullOrEmpty(model.RazaoSocial) ? model.RazaoSocial : update.RazaoSocial;
            update.Observacao = !string.IsNullOrEmpty(model.Observacao) ? model.Observacao : update.Observacao;
            update.Email = !string.IsNullOrEmpty(model.Email) ? model.Email : update.Email;
            update.HomePage = !string.IsNullOrEmpty(model.HomePage) ? model.HomePage : update.HomePage;
            update.RamoAtividadeId = model.RamoAtividadeId > 0 ? model.RamoAtividadeId : update.RamoAtividadeId;
            update.DataAlteracao = DateTime.Now;
            if (model.FornecedorTelefone != null)
            {
                var updateTelefoneOK = false;
                foreach (var telefone in model.FornecedorTelefone)
                {
                    if (telefone.flgDelete)
                    {
                        updateTelefoneOK = new FornecedorTelefoneBusiness().Delete(telefone.Id);
                    }
                    else
                    {
                        updateTelefoneOK = new FornecedorTelefoneBusiness().Update(telefone);
                    }
                }

                if (updateTelefoneOK)
                    update.FornecedorTelefone = null;
            }

            var updateEnderecoOK = new FornecedorEnderecoBusiness().Update(model.FornecedorEndereco.FirstOrDefault());

            if (updateEnderecoOK)
                update.FornecedorEndereco = model.FornecedorEndereco != null ? model.FornecedorEndereco : update.FornecedorEndereco;

            var contatos = new List<FornecedorContatoModel>();


            if (model.ContatoNome != null)
            {
                for (int i = 0; i < model.ContatoNome.Length; i++)
                {
                    if (!string.IsNullOrEmpty(model.ContatoNome[i]) && !string.IsNullOrEmpty(model.ContatoEmail[i]))
                    {
                        FornecedorContatoModel c = new FornecedorContatoModel
                        {
                            Id = string.IsNullOrEmpty(model.ContatoId[i]) ? 0 : Convert.ToInt32(model.ContatoId[i]),
                            Nome = model.ContatoNome[i],
                            Email = model.ContatoEmail[i],
                            Skype = model.ContatoSkype[i],
                            flgDelete = string.IsNullOrEmpty(model.ContatoFlgDelete[i]) ? false : Convert.ToBoolean(model.ContatoFlgDelete[i]),
                            Ativo = true,
                            DataCadastro = DateTime.Now,
                            FornecedorId = model.Id
                        };
                        contatos.Add(c);
                    }
                }

                var contatoFornecedor = new FornecedorContato.FornecedorContatoBusiness().Update(contatos);

                if (contatoFornecedor)
                    update.FornecedorContato = null;
            }

            var dadosBancarios = new List<FornecedorDadosBancariosModel>();

            if (model.Conta != null)
            {
                for (int i = 0; i < model.Conta.Length; i++)
                {
                    if (string.IsNullOrEmpty(model.ContaFlgDelete[i]))
                        model.ContaFlgDelete[i] = "false";

                    if (!string.IsNullOrEmpty(model.Conta[i]) && !string.IsNullOrEmpty(model.Agencia[i]) && Convert.ToBoolean(model.ContaFlgDelete[i]) == false)
                    {
                        FornecedorDadosBancariosModel c = new FornecedorDadosBancariosModel
                        {
                            Id = Convert.ToInt16(model.ContaId[i]),
                            Agencia = model.Agencia[i],
                            Conta = model.Conta[i],
                            BancoId = Convert.ToInt16(model.BancoId[i]),
                            Tipo = model.TipoConta[i],
                            Ativo = true,
                            DataCadastro = DateTime.Now,
                            flgDelete = string.IsNullOrEmpty(model.ContaFlgDelete[i]) ? false : Convert.ToBoolean(model.ContaFlgDelete[i]),

                        };
                        dadosBancarios.Add(c);
                    }
                }
            }
            var dadosBancariosFornecedor = new FornecedoresDadosBancarios.FornecedorDadosBancariosBusiness().Update(dadosBancarios);

            if(dadosBancariosFornecedor)
                update.FornecedorDadosBancarios = dadosBancarios;


            #endregion

            return _rep.Update(update);
        }

        /// <summary>
        /// Capturar Fornecedor pelo nome
        /// </summary>
        /// <param name="nome">Nome do Fornecedor</param>
        /// <returns></returns>
        public List<FornecedorModel> FiltroFornecedorByName(string nome)
        {
            return _rep.Where(n => n.RazaoSocial.ToLower().Contains(nome.ToLower()) || n.NomeFantasia.ToLower().Contains(nome.ToLower())).ToList().ConvertAll<FornecedorModel>(x => x);
        }
    }
}
