using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;
using Exploreh.Model.Cidade;
using Exploreh.Model.Banco;

namespace Exploreh.Model.Fornecedor
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ops! O campo razão social é obrigatório")]
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage = "Ops! O campo documento é obrigatório")]
        public string Documento { get; set; }
        public int RamoAtividadeId { get; set; }
        [Required(ErrorMessage = "Ops! O campo e-mail é obrigatório")]
        public string Email { get; set; }
        public string HomePage { get; set; }
        public string Observacao { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public virtual List<FornecedorEnderecoModel> FornecedorEndereco { get; set; }
        public virtual List<FornecedorTelefoneModel> FornecedorTelefone { get; set; }
        public virtual List<FornecedorContatoModel> FornecedorContato { get; set; }

        public virtual List<FornecedorDadosBancariosModel> FornecedorDadosBancarios { get; set; }
        public virtual RamoAtividade RamoAtividade { get; set; }

        public List<RamoAtividadeModel> RamosAtividade { get; set; }
        public List<BancoModel> Bancos { get; set; }

        public string[] ContatoId { get; set; }
        public string[] ContatoNome { get; set; }
        public string[] ContatoEmail { get; set; }
        public string[] ContatoSkype { get; set; }
        public string[] ContatoFlgDelete { get; set; }


        public string[] ContaId { get; set; }
        public string[] BancoId { get; set; }
        public string[] Agencia { get; set; }
        public string[] Conta { get; set; }
        public string[] TipoConta { get; set; }
        public string[] ContaFlgDelete { get; set; }

        #region Cidade / Estado
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
        public List<CidadeModel> Cidade { get; set; }
        #endregion

        public static implicit operator FornecedorModel(Database.Fornecedor c)
        {
            return new FornecedorModel
            {
                Id = c.Id,
                RazaoSocial = c.RazaoSocial,
                Email = c.Email,
                HomePage = c.HomePage,
                Observacao = c.Observacao,
                NomeFantasia = c.NomeFantasia,
                RamoAtividadeId = c.RamoAtividadeId,
                Documento = c.Documento,                
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                FornecedorEndereco = c.FornecedorEndereco?.ToList().ConvertAll<FornecedorEnderecoModel>(x => x) ?? new List<FornecedorEnderecoModel>(),
                FornecedorTelefone = c.FornecedorTelefone?.ToList().ConvertAll<FornecedorTelefoneModel>(x => x) ?? new List<FornecedorTelefoneModel>(),
                FornecedorContato = c.FornecedorContato?.ToList().ConvertAll<FornecedorContatoModel>(x=>x) ?? new List<FornecedorContatoModel>(),
                FornecedorDadosBancarios = c.FornecedorDadosBancarios?.ToList().ConvertAll<FornecedorDadosBancariosModel>(x=>x)?? new List<FornecedorDadosBancariosModel>(),
                Ativo = c.Ativo
             };
        }

        public static implicit operator Database.Fornecedor(FornecedorModel c)
        {
            return new Database.Fornecedor
            {
                Id = c.Id,
                RazaoSocial = c.RazaoSocial,
                Email = c.Email,
                HomePage = c.HomePage,
                Observacao = c.Observacao,
                NomeFantasia = c.NomeFantasia,
                RamoAtividadeId = c.RamoAtividadeId,
                Documento = c.Documento,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                FornecedorEndereco = c.FornecedorEndereco?.ToList().ConvertAll<FornecedorEndereco>(x => x) ?? new List<FornecedorEndereco>(),
                FornecedorTelefone = c.FornecedorTelefone?.ToList().ConvertAll<FornecedorTelefone>(x => x) ?? new List<FornecedorTelefone>(),
                FornecedorContato = c.FornecedorContato?.ToList().ConvertAll<FornecedorContato>(x => x) ?? new List<FornecedorContato>(),
                FornecedorDadosBancarios = c.FornecedorDadosBancarios?.ToList().ConvertAll<FornecedorDadosBancarios>(x => x) ?? new List<FornecedorDadosBancarios>(),
                Ativo = c.Ativo
            };
        }
    }
}
