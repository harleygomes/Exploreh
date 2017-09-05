using System;
using System.Collections.Generic;
using System.Linq;
using Exploreh.Model.Cliente;
using Exploreh.Repository.Repository;
using Exploreh.Business.Estado;

namespace Exploreh.Business.Cliente
{
    public class ClienteBusiness
    {
        
        private readonly GenericRepository<Database.Cliente> _rep = new GenericRepository<Database.Cliente>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteModel> Get()
        {
            return _rep.Get().Where(a => a.Ativo).ToList().ConvertAll<ClienteModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteModel> GetCep()
        {
            return _rep.Get().Where(a => a.Ativo).ToList().ConvertAll<ClienteModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteModel Get(int id)
        {
            ClienteModel cliente = _rep.Get(id);
            foreach (var clienteEndereco in cliente.ClienteEndereco)
            {
                clienteEndereco.IdEstado = (int)new Cidade.CidadeBusiness().Get((int)clienteEndereco.IdCidade).IdUnidadeFederacao;
                clienteEndereco.IdPais = (int)new Estado.EstadoBusiness().Get((int)clienteEndereco.IdEstado).IdPais;
            }

            return cliente;
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
            model.ClienteTelefone.ToList().ForEach(t =>
            {
                t.DataCadastro = DateTime.Now;
                t.Ativo = true;
                if (string.IsNullOrEmpty(t.Ddd) && string.IsNullOrEmpty(t.TipoTelefone) &&
                    string.IsNullOrEmpty(t.Telefone))
                {
                    model.ClienteTelefone.Remove(t);
                }
            });
            model.ClienteEndereco.ToList().ForEach(t =>
            {
                t.DataCadastro = DateTime.Now;
                t.Ativo = true;
            });
            var contatos = new List<ClienteContatoModel>();

            if (model.ContatoNome != null)
            {
                for (int i = 0; i < model.ContatoNome.Length; i++)
                {
                    if (!string.IsNullOrEmpty(model.ContatoNome[i]) && !string.IsNullOrEmpty(model.ContatoEmail[i]))
                    {
                        ClienteContatoModel c = new ClienteContatoModel
                        {
                            Nome = model.ContatoNome[i],
                            Email = model.ContatoEmail[i],
                            Ativo = true,
                            DataCadastro = DateTime.Now
                        };
                        contatos.Add(c);
                    }
                }
            }
            model.ClienteContato = contatos;
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
            update.Nome = !string.IsNullOrEmpty(model.Nome) ? model.Nome : update.Nome;
            update.TipoPessoa = !string.IsNullOrEmpty(model.TipoPessoa) ? model.TipoPessoa : update.TipoPessoa;
            update.Documento = !string.IsNullOrEmpty(model.Documento) ? model.Documento : update.Documento;
            update.Sexo = !string.IsNullOrEmpty(model.Sexo) ? model.Sexo : update.Sexo;
            update.DataNascimento = model.DataNascimento != null ? model.DataNascimento : update.DataNascimento;
            update.Ocupacao = !string.IsNullOrEmpty(model.Ocupacao) ? model.Ocupacao : update.Ocupacao;
            update.Email = !string.IsNullOrEmpty(model.Email) ? model.Email : update.Email;
            update.HomePage = !string.IsNullOrEmpty(model.HomePage) ? model.HomePage : update.HomePage;
            update.DataAlteracao = DateTime.Now;
            if (model.ClienteTelefone != null)
            {
                var updateTelefoneOK = false;
                foreach (var telefone in model.ClienteTelefone)
                {
                    if (telefone.flgDelete)
                    {
                        updateTelefoneOK = new ClienteTelefoneBusiness().Delete(telefone.Id);
                    }
                    else
                    {
                        updateTelefoneOK = new ClienteTelefoneBusiness().Update(telefone);
                    }
                }

                if (updateTelefoneOK)
                    update.ClienteTelefone = null;
            }

            var updateEnderecoOK = new ClienteEnderecoBusiness().Update(model.ClienteEndereco.FirstOrDefault());

            if (updateEnderecoOK)
                update.ClienteEndereco = model.ClienteEndereco != null ? model.ClienteEndereco : update.ClienteEndereco;

            var contatos = new List<ClienteContatoModel>();


            if (model.ContatoNome != null)
            {
                for (int i = 0; i < model.ContatoNome.Length; i++)
                {
                    if (!string.IsNullOrEmpty(model.ContatoNome[i]) && !string.IsNullOrEmpty(model.ContatoEmail[i]))
                    {
                        ClienteContatoModel c = new ClienteContatoModel
                        {
                            Id = string.IsNullOrEmpty(model.ContatoId[i])? 0 : Convert.ToInt32(model.ContatoId[i]),
                            Nome = model.ContatoNome[i],
                            Email = model.ContatoEmail[i],
                            flgDelete = string.IsNullOrEmpty(model.ContatoFlgDelete[i]) ? false : Convert.ToBoolean(model.ContatoFlgDelete[i]),
                            Ativo = true,
                            DataCadastro = DateTime.Now,
                            ClienteId = model.Id
                        };
                        contatos.Add(c);
                    }
                }

                var contatoCliente = new ClienteContato.ClienteContatoBusiness().Update(contatos);

                if (contatoCliente)
                    update.ClienteContato = null;
            }
            
            #endregion

            return _rep.Update(update);
        }

        /// <summary>
        /// Capturar cliente pelo nome
        /// </summary>
        /// <param name="nome">Nome do cliente</param>
        /// <returns></returns>
        public List<ClienteModel> FiltroClienteByName(string nome)
        {
            return _rep.Where(n=>n.Nome.ToLower().Contains(nome.ToLower())).ToList().ConvertAll<ClienteModel>(x=>x);
        }

        /// <summary>
        /// Validando se já existe um documento cadastrado
        /// </summary>
        /// <param name="documento">RG / CNPJ / Extrangeiro </param>
        /// <returns>Boleano Any()</returns>
        public bool ExisteDcumento(string documento)
        {
            return _rep.Where(n => n.Documento.Replace(".", "").Replace("/", "").Replace("-", "") == documento).Any();
        }
    }
}
