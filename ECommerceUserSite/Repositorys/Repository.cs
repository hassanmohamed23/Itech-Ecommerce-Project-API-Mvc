using DBContext;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class Repository<T> :IRepository<T> where T : class
    {
        myDbContext context;
        DbSet<T> Table;
        public Repository(myDbContext _context)
        {
            context = _context;
            Table = context.Set<T>();
        }
        //Get All
        public async Task<IEnumerable<T>> GetAsync()
        {
            return  Table;
        }
        //Get By ID
        public async Task<T> GetByIDAsync(int Id)
        {
            return await Table.FindAsync(Id);
        }
 
          //Get By Lamada Experssion
        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return  Table.Where(expression).AsNoTracking();
        }



        public async Task<T> Add(T entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            Table.Update(entity);
            return entity;
        }
        public async Task<T> UpdatePatch(int id, JsonPatchDocument entity)
        {
            T Temp = await Table.FindAsync(id);
            entity.ApplyTo(Temp);
            return Temp;
        }
        public async Task<T> Remove(T entity)
        {
            Table.Remove(entity);
            return entity;
        }


    }
}
