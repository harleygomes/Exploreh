using System.Collections.Generic;

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
        bool Add(T entity);
        bool Delete(int id);
        bool Update(T entityc);
    }
}
