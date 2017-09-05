using Exploreh.Model.Cidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploreh.Model.Estado
{
    public class EstadoModel
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        
        public virtual ICollection<CidadeModel> Cidade { get; set; }
    }
}
