using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Perfil;
using Exploreh.Model.Telas;
using Exploreh.Repository.Base;

namespace Exploreh.Repository.Telas
{
    public class TelasRepository
    {
        private BaseRepository<Database.Telas> repository;

        public TelasRepository()
        {
            this.repository = new BaseRepository<Database.Telas>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TelasModel> Get()
        {
            return this.repository.Get().ConvertAll<TelasModel>(x => x);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TelasModel Get(int id)
        {
            return this.repository.Get(id);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(TelasModel model)
        {
            return this.repository.Update(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(TelasModel model)
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
