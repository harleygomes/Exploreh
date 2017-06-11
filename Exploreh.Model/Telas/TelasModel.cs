﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Perfil;

namespace Exploreh.Model.Telas
{
    public class TelasModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public virtual ICollection<PerfilModel> PerfilModel { get; set; }

        public static implicit operator TelasModel(Database.Tela telas)
        {
            return new TelasModel
            {
                Id = telas.Id,
                Nome = telas.Nome,
                Ativo = telas.Ativo,
                DataCadastro = telas.DataCadastro,
                DataAlteracao = telas.DataAlteracao
            };
        }

        public static implicit operator Database.Tela(TelasModel telas)
        {
            return new Database.Tela
            {
                Id = telas.Id,
                Nome = telas.Nome,
                Ativo = telas.Ativo,
                DataCadastro = telas.DataCadastro,
                DataAlteracao = telas.DataAlteracao
            };
        }
    }
}
