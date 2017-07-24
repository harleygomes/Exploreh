using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Perfil;
using Exploreh.Model.Telas;

namespace Exploreh.Model.Permissao
{
    public class PermissaoModel
    {
        //public int Id { get; set; }
        //public bool Ativo { get; set; }
        //public string Descricao { get; set; }
        //public string Perfil { get; set; }
        //public string Tela { get; set; }

        public int Id{ get; set; }
        public string Nome { get; set; }
        public int PerfilId { get; set; }
        public List<PerfilModel> Perfis { get; set; }
    }
}
