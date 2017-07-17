using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cliente;
using Exploreh.Model.UnidadeFederacao;

namespace Exploreh.Model.Bairro
{
    public class BairroModel
    {
        public int IdBairro { get; set; }
        public Nullable<int> IdCidade { get; set; }
        public string DcrChaveLocalidade { get; set; }
        public string DcrChaveBairro { get; set; }
        public string DcrNome { get; set; }
        public string AbrevNome { get; set; }
        public Nullable<System.DateTime> DataReg { get; set; }
        public string EstReg { get; set; }

        public static implicit operator BairroModel(Database.TblBairro bairro)
        {
            return new BairroModel
            {
                IdBairro = bairro.IdBairro,
                IdCidade = bairro.IdCidade,
                DcrChaveLocalidade = bairro.DcrChaveLocalidade,
                DcrChaveBairro = bairro.DcrChaveBairro,
                DcrNome = bairro.DcrNome,
                AbrevNome = bairro.AbrevNome,
                DataReg = bairro.DataReg,
                EstReg = bairro.EstReg
            };
        }

        public static implicit operator Database.TblBairro(BairroModel bairro)
        {
            return new Database.TblBairro
            {
                IdBairro = bairro.IdBairro,
                IdCidade = bairro.IdCidade,
                DcrChaveLocalidade = bairro.DcrChaveLocalidade,
                DcrChaveBairro = bairro.DcrChaveBairro,
                DcrNome = bairro.DcrNome,
                AbrevNome = bairro.AbrevNome,
                DataReg = bairro.DataReg,
                EstReg = bairro.EstReg
            };
        }
    }
}
