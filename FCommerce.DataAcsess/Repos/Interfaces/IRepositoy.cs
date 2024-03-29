﻿using System.Linq.Expressions;

namespace FCommerce.DataAcsess.Repos.Interfaces
{
    public interface IRepositoy<T> where T : class
    {
        void Add(T entity);
        void Edit(T entity);
        void DeleteNormal(T entity);
        void DeleteRange(IEnumerable<T> entities);
        T Get(int id);
       
        T Get(Expression<Func<T, bool>> filter, string? includeProps = null);

        IEnumerable<T> GetAll(string? includeProps=null);

    }
}
