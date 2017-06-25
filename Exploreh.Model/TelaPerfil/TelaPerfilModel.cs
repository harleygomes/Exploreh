using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Perfil;
using Exploreh.Model.Telas;

namespace Exploreh.Model.TelaPerfil
{
    public class TelaPerfilModel
    {
        public int Perfil_Id { get; set; }
        public int Tela_Id { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public int Id { get; set; }

        public virtual PerfilModel Perfil { get; set; }
        public virtual TelaModel Tela { get; set; }


    }
}
