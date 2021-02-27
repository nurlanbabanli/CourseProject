using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core
{
    public interface IEntityRepository<TEntity> where TEntity: class, IEntity,new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression=null);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
