using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Exploreh.Repository.IBase
{
    /// <summary>
    /// Contrato obrigatório e basico para um CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : class
    {
        List<T> Get();
        T Get(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        bool Add(T entity);
        bool Delete(int id);
        bool Update(T entityc);
    }
}
