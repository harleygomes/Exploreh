using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;

namespace Exploreh.Model.Cliente
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoPessoa { get; set; }
        public string Documento { get; set; }
        public string Sexo { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public string Ocupacao { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public virtual List<ClienteEnderecoModel> ClienteEndereco { get; set; }
        public virtual List<ClienteTelefoneModel> ClienteTelefone { get; set; }

        public static implicit operator ClienteModel(Database.Cliente c)
        {
            return new ClienteModel
            {
                Id = c.Id,
                Nome = c.Nome,
                TipoPessoa = c.TipoPessoa,
                Documento = c.Documento,
                Sexo = c.Sexo,
                DataNascimento = c.DataNascimento,
                Ocupacao = c.Ocupacao,
                Email = c.Email,
                HomePage = c.HomePage,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                ClienteEndereco = c.ClienteEndereco?.ToList().ConvertAll<ClienteEnderecoModel>(x => x) ?? new List<ClienteEnderecoModel>(),
                ClienteTelefone = c.ClienteTelefone?.ToList().ConvertAll<ClienteTelefoneModel>(x => x) ?? new List<ClienteTelefoneModel>(),
                Ativo = c.Ativo
             };
        }

        public static implicit operator Database.Cliente(ClienteModel c)
        {
            return new Database.Cliente
            {
                Id = c.Id,
                Nome = c.Nome,
                TipoPessoa = c.TipoPessoa,
                Documento = c.Documento,
                Sexo = c.Sexo,
                DataNascimento = c.DataNascimento,
                Ocupacao = c.Ocupacao,
                Email = c.Email,
                HomePage = c.HomePage,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                ClienteEndereco = c.ClienteEndereco?.ToList().ConvertAll<ClienteEndereco>(x => x) ?? new List<ClienteEndereco>(),
                ClienteTelefone = c.ClienteTelefone?.ToList().ConvertAll<ClienteTelefone>(x => x) ?? new List<ClienteTelefone>(),
                Ativo = c.Ativo
            };
        }
    }
}
