using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.PerfilTela;
using Exploreh.Repository.Repository;

namespace Exploreh.Business.PerfilTela
{
    public class PerfilTelaBusiness
    {
        private readonly GenericRepository<Database.PerfilTela> _rep = new GenericRepository<Database.PerfilTela>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PerfilTelaModel> Get()
        {
            return _rep.Get().ToList().ConvertAll<PerfilTelaModel>(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PerfilTelaModel Get(int id)
        {
            return _rep.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(PerfilTelaModel model)
        {
            return _rep.Add(new PerfilTelaModel
            {
                Perfil_Id = model.Perfil_Id,
                Tela_Id = model.Tela_Id,
                DataCadastro = DateTime.Now
            });
        }

        public bool Update(PerfilTelaModel model)
        {
            var result = Get(model.Id);

            var deleted = Delete(result.Id);

            return deleted && this.Add(model);
        }

        public bool Delete(int id)
        {
            return _rep.Delete(id);
        }
    }
}
