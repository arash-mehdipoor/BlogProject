using Blog.Domain.Common.Entities;
using Blog.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Common
{
    public class EfRepository<TEntity> : IRepasitory<TEntity> where TEntity : Entity, new()
    {
        private readonly BlogDatabaseContext dbContext;

        public EfRepository(BlogDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return dbContext.Set<TEntity>().Any(expression);
        }

        public TEntity Get(int Id)
        {
            return dbContext.Set<TEntity>().FirstOrDefault(t => t.Id == Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public void SaveChange()
        {
            dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
