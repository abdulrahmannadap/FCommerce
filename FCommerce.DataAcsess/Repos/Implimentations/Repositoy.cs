using FCommerce.DataAcsess.Repos.Interfaces;
using FCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace FCommerce.DataAcsess.Repos.Implimentations
{
    public class Repositoy<T> : IRepositoy<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repositoy(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void DeleteNormal(T entity)
        {
            _dbSet.Remove(entity);
             
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }


        public void Edit(T entity)
        {
            _dbSet.Update(entity);
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeProps = null)
        {
            IQueryable<T> query = _dbSet;
            if (string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.SingleOrDefault(filter);
        }


        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = _dbSet;

           
            if(!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                   query = query.Include(includeProps);
                }
            }

            return query.ToList();
        }
    }
}
