using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using FAS.FirehousePro.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FAS.FirehousePro.EntityFramework.Repositories
{
    public abstract class FirehouseProRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<FirehouseProDbContext, TEntity, TPrimaryKey>,
        IFirehoueProRepoOfTPrimaryKey<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected FirehouseProRepositoryBase(IDbContextProvider<FirehouseProDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<TEntity>> GetAllListWithAsync(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = GetAllIncluding(propertySelectors);
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetWithAsync(TPrimaryKey id, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = GetAllIncluding(propertySelectors);

            //Builds this (e => e.Id == id)
            var arg = Expression.Parameter(typeof(TEntity), "e");
            var predicate = Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(
                    Expression.Property(arg, "Id"),
                    Expression.Constant(id)),
                arg);

            return await query.SingleAsync(predicate);
        }
    }

    public abstract class FirehouseProRepositoryBase<TEntity> : FirehouseProRepositoryBase<TEntity, int>, 
        IFirehoueProRepo<TEntity>
        where TEntity : class, IEntity<int>
    {
        protected FirehouseProRepositoryBase(IDbContextProvider<FirehouseProDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
