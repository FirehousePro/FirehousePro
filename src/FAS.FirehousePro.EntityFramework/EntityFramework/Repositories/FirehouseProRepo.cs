using Abp.Domain.Entities;
using Abp.EntityFramework;
using FAS.FirehousePro.Core;

namespace FAS.FirehousePro.EntityFramework.Repositories
{
    public class FirehouseProRepo<TEntity> : FirehouseProRepositoryBase<TEntity>, IFirehoueProRepo<TEntity>
        where TEntity : class, IEntity<int>
    {
        public FirehouseProRepo(IDbContextProvider<FirehouseProDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
