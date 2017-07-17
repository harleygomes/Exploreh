using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cliente;
using Exploreh.Model.UnidadeFederacao;

namespace Exploreh.Model.Cidade
{
    public class CidadeModel
    {
        public int IdCidade { get; set; }
        public Nullable<int> IdUnidadeFederacao { get; set; }
        public string DcrSiglaPais { get; set; }
        public string DcrSiglaUf { get; set; }
        public string DcrChaveLocalidade { get; set; }
        public string DcrNome { get; set; }
        public string DcrCep { get; set; }
        public string AbrevNome { get; set; }
        public string TipLocalidade { get; set; }
        public string SituacaoLocalidade { get; set; }

        public Nullable<System.DateTime> DataReg { get; set; }
        public string EstReg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<ClienteEnderecoModel> ClienteEndereco { get; set; }
        public virtual UnidadeFederacaoModel TblUnidadeFederacao { get; set; }

        public static implicit operator CidadeModel(Database.TblCidade cidade)
        {
            return new CidadeModel
            {
                IdCidade = cidade.IdCidade,
                IdUnidadeFederacao = cidade.IdUnidadeFederacao,
                DcrSiglaPais = cidade.DcrSiglaPais,
                DcrSiglaUf = cidade.DcrSiglaUf,
                DcrChaveLocalidade = cidade.DcrChaveLocalidade,
                DcrNome = cidade.DcrNome,
                DcrCep = cidade.DcrCep,
                AbrevNome = cidade.AbrevNome,
                TipLocalidade = cidade.TipLocalidade,
                SituacaoLocalidade = cidade.SituacaoLocalidade,
                DataReg = cidade.DataReg,
                EstReg = cidade.EstReg

                //ClienteEndereco = cidade.ClienteEndereco.ToList().ConvertAll<CidadeModel>(x=>x)
            };
        }

        public static implicit operator Database.TblCidade(CidadeModel cidade)
        {
            return new Database.TblCidade
            {
                IdCidade = cidade.IdCidade,
                IdUnidadeFederacao = cidade.IdUnidadeFederacao,
                DcrSiglaPais = cidade.DcrSiglaPais,
                DcrSiglaUf = cidade.DcrSiglaUf,
                DcrChaveLocalidade = cidade.DcrChaveLocalidade,
                DcrNome = cidade.DcrNome,
                DcrCep = cidade.DcrCep,
                AbrevNome = cidade.AbrevNome,
                TipLocalidade = cidade.TipLocalidade,
                SituacaoLocalidade = cidade.SituacaoLocalidade,
                DataReg = cidade.DataReg,
                EstReg = cidade.EstReg
                //ClienteEndereco = cidade.ClienteEndereco.ToList().ConvertAll<Database.Cidade>(x=>x)
            };
        }
    }
}
