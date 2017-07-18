using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Logradouro;
using Exploreh.Repository.Repository;
using Exploreh.Business.Estado;
using Exploreh.Business.Pais;
using Exploreh.Model.Cidade;
using Exploreh.Model.UnidadeFederacao;
using Exploreh.Model.Pais;

namespace Exploreh.Business.Logradouro
{
    public class LogradouroBusiness
    {
        private readonly GenericRepository<Database.TblLogradouro> _rep;

        public LogradouroBusiness()
        {
            this._rep = new GenericRepository<Database.TblLogradouro>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<LogradouroModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<LogradouroModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LogradouroModel Get(int id)
        {
            return _rep.Get(id);
        }

        public List<LogradouroModel> GetLogradouro(int id)
        {
            return _rep.Get().Where(c => c.IdLogradouro == id).ToList().ConvertAll<LogradouroModel>(x => x);
        }

        public LogradouroModel GetCep(string cep)
        {
            LogradouroModel logradouro = _rep.Where(i=>i.DcrCep == cep).AsQueryable().FirstOrDefault();

            logradouro.Bairro = logradouro.IdBairro != null ? new Bairro.BairroBusiness().Get((int)logradouro.IdBairro) : new Model.Bairro.BairroModel();
            logradouro.Cidade = logradouro.Bairro.IdCidade != null ? new Cidade.CidadeBusiness().Get((int)logradouro.Bairro.IdCidade) : new CidadeModel();
            logradouro.UnidadeFederacao = logradouro.Cidade.IdUnidadeFederacao != null ? new EstadoBusiness().Get((int)logradouro.Cidade.IdUnidadeFederacao) : new UnidadeFederacaoModel();
            logradouro.Pais = logradouro.UnidadeFederacao.IdPais != null ? new PaisBusiness().Get((int)logradouro.UnidadeFederacao.IdPais) : new PaisModel();

            return logradouro;
        }

    }
}
