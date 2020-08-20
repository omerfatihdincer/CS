using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CS.Core.DataAccess
{
    public interface IEntityRepositoryBase<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);

        IList<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
