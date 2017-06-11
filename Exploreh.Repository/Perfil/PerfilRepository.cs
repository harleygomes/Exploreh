using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Perfil;
using Exploreh.Model.Usuario;
using Exploreh.Repository.Base;

namespace Exploreh.Repository.Perfil
{
    public class PerfilRepository
    {
        private BaseRepository<Database.Perfil> repository;

        public PerfilRepository()
        {
            this.repository = new BaseRepository<Database.Perfil>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PerfilModel> Get()
        {
            return this.repository.Get().ConvertAll<PerfilModel>(x => x);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PerfilModel Get(int id)
        {
            return this.repository.Get(id);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(PerfilModel model)
        {
            return this.repository.Update(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(PerfilModel model)
        {
            return this.repository.Add(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return this.repository.Delete(this.repository.Get(id));
        }
    }
}
