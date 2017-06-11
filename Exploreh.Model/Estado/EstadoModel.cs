using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cidade;
using Exploreh.Model.Cliente;

namespace Exploreh.Model.Estado
{
    public class EstadoModel
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<CidadeModel> Cidade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<ClienteEnderecoModel> ClienteEndereco { get; set; }

        public static implicit operator EstadoModel(Database.Estado estado)
        {
            return new EstadoModel
            {
                Id = estado.Id,
                Nome = estado.Nome,
                Sigla = estado.Sigla,
                Cidade = estado.Cidade.ToList().ConvertAll<CidadeModel>(x=>x)
            };
        }
        public static implicit operator Database.Estado(EstadoModel estado)
        {
            return new Database.Estado
            {
                Id = estado.Id,
                Nome = estado.Nome,
                Sigla = estado.Sigla,
                Cidade = estado.Cidade.ToList().ConvertAll<Database.Cidade>(x => x)
            };
        }
    }
}
