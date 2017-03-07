using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace FAS.FirehousePro.EntityFramework.Repositories
{
    public abstract class FirehouseProRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<FirehouseProDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected FirehouseProRepositoryBase(IDbContextProvider<FirehouseProDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class FirehouseProRepositoryBase<TEntity> : FirehouseProRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected FirehouseProRepositoryBase(IDbContextProvider<FirehouseProDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
