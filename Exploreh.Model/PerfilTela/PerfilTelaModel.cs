using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploreh.Model.PerfilTela
{
    public class PerfilTelaModel
    {
        public int Perfil_Id { get; set; }
        public int Tela_Id { get; set; }
        public DateTime DataCadastro { get; set; }

        public static implicit operator PerfilTelaModel(Database.PerfilTela perfiltela)
        {
            return new PerfilTelaModel
            {
                Perfil_Id = perfiltela.Perfil_Id,
                Tela_Id = perfiltela.Tela_Id,
                DataCadastro = perfiltela.DataCadastro,
                
            };
        }
        public static implicit operator Database.PerfilTela(PerfilTelaModel perfiltela)
        {
            return new Database.PerfilTela
            {
               Perfil_Id = perfiltela.Perfil_Id,
               Tela_Id = perfiltela.Tela_Id,
                DataCadastro = perfiltela.DataCadastro
            };
        }
    }
}
