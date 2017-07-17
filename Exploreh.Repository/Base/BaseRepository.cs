using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Exploreh.Database;
using System.Linq.Expressions;

namespace Exploreh.Repository.Base
{
    /// <summary>
    /// Esta classe tenta otimizar o esforço quanto a criação de CRUD´s recorrentes em nossos projetos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> where T : class
    {
        private ExplorehEntities _db;
        private IDbSet<T> entities;

        public BaseRepository()
        {
            this._db = new ExplorehEntities();
        }

        /// <summary>
        /// Método que retorna uma entidade pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            return this.Entities.Find(id);
        }


        /// <summary>
        /// Método que retorna uma lista "T"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<T> Get()
        {
            return this.Entities.ToList();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return Entities.Where(expression);
        }

        /// <summary>
        /// Método que adiciona uma nova entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            try
            {
                if (entity == null) return false;

                this.Entities.Add(entity);
                return this._db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Método que atualiza uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            try
            {
                if (entity == null) return false;

                #region Alternativas viáveis
                /*this._db.Entry(entity).State = EntityState.Modified;*/
                /*this.Entities.Attach(entity);*/
                #endregion

                this._db.Set<T>().AddOrUpdate(entity);
                return this._db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Método que deleta uma entidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            try
            {
                if (entity == null) return false;

                this._db.Entry(entity).State = EntityState.Deleted;
                return this._db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.entities;
            }
        }

        /// <summary>
        /// Propriedade que identifica a entidade corrente
        /// </summary>
        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = _db.Set<T>();
                }
                return entities;
            }
        }

    }
}

