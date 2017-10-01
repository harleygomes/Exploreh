using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Database;
using Exploreh.Model.Perfil;
using Exploreh.Model.Telas;

namespace Exploreh.Model.PerfilTela
{
    public class PerfilTelaModel
    {
        public int Id { get; set; }
        public int Perfil_Id { get; set; }
        public int Tela_Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<TelaModel> Tela { get; set; }
        public List<PerfilModel> Perfil { get; set; }

        public static implicit operator PerfilTelaModel(Database.PerfilTela perfiltela)
        {
            if(perfiltela == null) return new PerfilTelaModel();

            return new PerfilTelaModel
            {
                Id = perfiltela.Id,
                Perfil_Id = perfiltela.Perfil_Id,
                Tela_Id = perfiltela.Tela_Id,
                DataCadastro = perfiltela.DataCadastro
                
            };
        }
        public static implicit operator Database.PerfilTela(PerfilTelaModel perfiltela)
        {
            if (perfiltela == null) return new Database.PerfilTela();

            return new Database.PerfilTela
            {
                Id = perfiltela.Id,
                Perfil_Id = perfiltela.Perfil_Id,
                Tela_Id = perfiltela.Tela_Id,
                DataCadastro = perfiltela.DataCadastro
            };
        }
    }
}
