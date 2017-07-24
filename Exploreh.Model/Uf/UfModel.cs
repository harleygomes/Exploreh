using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;
using Exploreh.Model.Cidade;

namespace Exploreh.Model.Uf
{
    public class UfModel
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        
        public virtual ICollection<CidadeModel> Cidade { get; set; }

        public static implicit operator UfModel(Database.Estado uf)
        {
            return new UfModel
            {
                Id = uf.Id,
                Sigla = uf.Sigla,
                Nome = uf.Nome
            };
        }
        public static implicit operator Database.Estado(UfModel uf)
        {
            return new Database.Estado
            {
                Id = uf.Id,
                Sigla = uf.Sigla,
                Nome = uf.Nome
            };
        }
    }
}
