using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIDAsync(int Id);
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> UpdatePatch(int id, JsonPatchDocument entity);
        Task<T> Remove(T entity);
    }
}
