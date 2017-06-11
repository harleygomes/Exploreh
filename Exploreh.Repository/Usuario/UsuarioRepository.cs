using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Model.Cliente;
using Exploreh.Model.Usuario;
using Exploreh.Repository.Base;

namespace Exploreh.Repository.Usuario
{
    public class UsuarioRepository
    {
        private BaseRepository<Database.Usuario> repository;

        public UsuarioRepository()
        {
            this.repository = new BaseRepository<Database.Usuario>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UsuarioModel> Get()
        {
            return this.repository.Get().ConvertAll<UsuarioModel>(x => x);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UsuarioModel Get(int id)
        {
            return this.repository.Get(id);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(UsuarioModel model)
        {
            return this.repository.Update(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(UsuarioModel model)
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
