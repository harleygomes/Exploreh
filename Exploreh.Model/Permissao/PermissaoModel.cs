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
        public int TelaId { get; set; }
        public List<TelaModel> Tela { get; set; }
        public int PerfilId { get; set; }
        public List<PerfilModel> Perfil { get; set; }
    }
}
