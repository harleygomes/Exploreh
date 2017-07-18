using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cidade;
using Exploreh.Model.Cliente;
using Exploreh.Model.UnidadeFederacao;

namespace Exploreh.Model.Pais
{
    public class PaisModel
    {
        public int IdPais { get; set; }
        public string DcrSigla { get; set; }
        public string DcrSigla2 { get; set; }
        public string DcrNome { get; set; }
        public string AbrevNome { get; set; }
        public Nullable<System.DateTime> DataReg { get; set; }
        public string EstReg { get; set; }
        public virtual List<UnidadeFederacaoModel> TblUnidadeFederacao { get; set; }

        public static implicit operator PaisModel(Database.TblPais pais)
        {
            return new PaisModel
            {
                IdPais = pais.IdPais,
                DcrSigla = pais.DcrSigla,
                DcrSigla2 = pais.DcrSigla2,
                DcrNome = pais.DcrNome,
                AbrevNome = pais.AbrevNome,
                DataReg = pais.DataReg,
                EstReg = pais.EstReg,
                //TblUnidadeFederacao = pais.TblUnidadeFederacao.ToList().ConvertAll<UnidadeFederacaoModel>(u=>u)
            };
        }
        public static implicit operator Database.TblPais(PaisModel pais)
        {
            return new Database.TblPais
            {
                IdPais = pais.IdPais,
                DcrSigla = pais.DcrSigla,
                DcrSigla2 = pais.DcrSigla2,
                DcrNome = pais.DcrNome,
                AbrevNome = pais.AbrevNome,
                DataReg = pais.DataReg,
                EstReg = pais.EstReg,
                //TblUnidadeFederacao = pais.TblUnidadeFederacao.ToList().ConvertAll<Database.TblUnidadeFederacao>(u => u)
            };
        }
    }
}
