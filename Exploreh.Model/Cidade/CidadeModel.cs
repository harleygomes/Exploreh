using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cliente;
using Exploreh.Model.Estado;

namespace Exploreh.Model.Cidade
{
    public class CidadeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public int EstadoId { get; set; }

        public virtual EstadoModel Estado { get; set; }
        public virtual List<ClienteEnderecoModel> ClienteEndereco { get; set; }

        public static implicit operator CidadeModel(Database.Cidade cidade)
        {
            return new CidadeModel
            {
                Id = cidade.Id,
                Nome = cidade.Nome,
                EstadoId = cidade.EstadoId,
                CEP = cidade.CEP,
                //ClienteEndereco = cidade.ClienteEndereco.ToList().ConvertAll<CidadeModel>(x=>x)
            };
        }

        public static implicit operator Database.Cidade(CidadeModel cidade)
        {
            return new Database.Cidade
            {
                Id = cidade.Id,
                Nome = cidade.Nome,
                EstadoId = cidade.EstadoId,
                CEP = cidade.CEP,
                //ClienteEndereco = cidade.ClienteEndereco.ToList().ConvertAll<Database.Cidade>(x=>x)
            };
        }
    }
    }
