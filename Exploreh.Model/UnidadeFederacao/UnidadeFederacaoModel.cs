using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cidade;
using Exploreh.Model.Cliente;

namespace Exploreh.Model.UnidadeFederacao
{
    public class UnidadeFederacaoModel
    {
           
        public int IdUnidadeFederacao { get; set; }
        public Nullable<int> IdPais { get; set; }
        public string DcrSiglaPais { get; set; }
        public string DcrSigla { get; set; }
        public string DcrChaveUf { get; set; }
        public string DcrNome { get; set; }
        public string AbrevNome { get; set; }
        public Nullable<System.DateTime> DataReg { get; set; }
        public string EstReg { get; set; }
        public virtual List<CidadeModel> Cidade { get; set; }
        public virtual Pais.PaisModel Pais { get; set; }
        public int? IdPaisEstrangeiro { get; set; }

        public static implicit operator UnidadeFederacaoModel(Database.TblUnidadeFederacao estado)
        {
            if (estado == null) return new UnidadeFederacaoModel();

            return new UnidadeFederacaoModel
            {
                IdUnidadeFederacao = estado.IdUnidadeFederacao,
                IdPais = estado.IdPais,
                DcrSiglaPais = estado.DcrSiglaPais,
                DcrSigla = estado.DcrSigla,
                DcrChaveUf = estado.DcrChaveUf,
                DcrNome = estado.DcrNome,
                AbrevNome = estado.AbrevNome,
                DataReg = estado.DataReg,
                EstReg = estado.EstReg,
                //Cidade = estado.TblCidade.ToList().ConvertAll<CidadeModel>(c=>c),
                Pais = estado.TblPais,
                IdPaisEstrangeiro = estado.IdPaisEstrangeiro
            };
        }
        public static implicit operator Database.TblUnidadeFederacao(UnidadeFederacaoModel estado)
        {
            return new Database.TblUnidadeFederacao
            {
                IdUnidadeFederacao = estado.IdUnidadeFederacao,
                IdPais = estado.IdPais,
                DcrSiglaPais = estado.DcrSiglaPais,
                DcrSigla = estado.DcrSigla,
                DcrChaveUf = estado.DcrChaveUf,
                DcrNome = estado.DcrNome,
                AbrevNome = estado.AbrevNome,
                DataReg = estado.DataReg,
                EstReg = estado.EstReg,
                //TblCidade = estado.Cidade.ToList().ConvertAll<Database.TblCidade>(c => c),
                //TblPais = estado.Pais,
                IdPaisEstrangeiro = estado.IdPaisEstrangeiro
            };
        }
    }
}
