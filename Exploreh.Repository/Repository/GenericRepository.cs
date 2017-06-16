﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Exploreh.Repository.Base;
using Exploreh.Repository.IBase;

namespace Exploreh.Repository.Repository
{
    /// <summary>
    /// Classe generalizada para atender o CRUD aceitando qualquer tipagem
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> where T: class 
    {
        
        private BaseRepository<T> repository;

        public GenericRepository()
        {
            this.repository = new BaseRepository<T>();
        }

        /// <summary>
        /// Lista de itens
        /// </summary>
        /// <returns>Retorna todos os itens da tabela sem filtros</returns>
        public List<T> Get()
        {
            return this.repository.Get().ConvertAll<T>(x => x);
        }

        /// <summary>
        /// Retorna a entidade(objeto) desejada pelo id
        /// </summary>
        /// <param name="id">Id do objeto desejado</param>
        /// <returns>Um único objeto pelo seu id</returns>
        public T Get(int id)
        {
            return this.repository.Get(id);
        }

        /// <summary>
        /// Atualiza um objeto
        /// </summary>
        /// <param name="model">Objeto tipado</param>
        /// <returns>true | false</returns>
        public bool Update(T model)
        {
            return this.repository.Update(model);
        }

        /// <summary>
        /// Adiciona um novo item
        /// </summary>
        /// <param name="model">Objeto tipado</param>
        /// <returns>true | false</returns>
        public bool Add(T model)
        {
            return this.repository.Add(model);
        }

        /// <summary>
        /// Exclui um item
        /// </summary>
        /// <param name="id">Exclui um item pelo seu id</param>
        /// <returns>true | false</returns>
        public bool Delete(int id)
        {
            return this.repository.Delete(this.repository.Get(id));
        }

    }
}
