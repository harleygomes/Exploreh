using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cliente;
using Exploreh.Model.UnidadeFederacao;

namespace Exploreh.Model.Logradouro
{
    public class LogradouroModel
    {
        public int IdLogradouro { get; set; }
        public Nullable<int> IdBairro { get; set; }
        public string DcrChaveBairroInicial { get; set; }
        public string DcrChaveBairroFinal { get; set; }
        public string DcrTipoLogradouro { get; set; }
        public string DcrPreposicao { get; set; }
        public string DcrTituloPatente { get; set; }
        public string DcrChaveLogradouro { get; set; }
        public string DcrNome { get; set; }
        public string AbrevNome { get; set; }
        public string DcrCep { get; set; }
        public Nullable<System.DateTime> DataReg { get; set; }
        public string EstReg { get; set; }

        public static implicit operator LogradouroModel(Database.TblLogradouro logradouro)
        {
            return new LogradouroModel
            {
                IdLogradouro = logradouro.IdLogradouro,
                IdBairro = logradouro.IdBairro,
                DcrChaveBairroInicial = logradouro.DcrChaveBairroInicial,
                DcrChaveBairroFinal = logradouro.DcrChaveBairroFinal,
                DcrTipoLogradouro = logradouro.DcrTipoLogradouro,
                DcrPreposicao = logradouro.DcrPreposicao,
                DcrTituloPatente = logradouro.DcrTituloPatente,
                DcrChaveLogradouro = logradouro.DcrChaveLogradouro,
                DcrNome = logradouro.DcrNome,
                DcrCep = logradouro.DcrCep,
                DataReg = logradouro.DataReg,
                EstReg = logradouro.EstReg,
            };
        }

        public static implicit operator Database.TblLogradouro(LogradouroModel logradouro)
        {
            return new Database.TblLogradouro
            {
                IdLogradouro = logradouro.IdLogradouro,
                IdBairro = logradouro.IdBairro,
                DcrChaveBairroInicial = logradouro.DcrChaveBairroInicial,
                DcrChaveBairroFinal = logradouro.DcrChaveBairroFinal,
                DcrTipoLogradouro = logradouro.DcrTipoLogradouro,
                DcrPreposicao = logradouro.DcrPreposicao,
                DcrTituloPatente = logradouro.DcrTituloPatente,
                DcrChaveLogradouro = logradouro.DcrChaveLogradouro,
                DcrNome = logradouro.DcrNome,
                DcrCep = logradouro.DcrCep,
                DataReg = logradouro.DataReg,
                EstReg = logradouro.EstReg,
            };
        }
    }
}
