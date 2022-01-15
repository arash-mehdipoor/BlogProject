using Blog.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Common.Interfaces
{
    public interface IRepasitory<TEntity> where TEntity : Entity, new()
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void SaveChange();
        bool Exists(Expression<Func<TEntity, bool>> expression);
    }
}
