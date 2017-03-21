using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Core
{
    public interface IFirehoueProRepoOfTPrimaryKey<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        Task<List<TEntity>> GetAllListWithAsync(params Expression<Func<TEntity, object>>[] propertySelectors);
    }

    public interface IFirehoueProRepo<TEntity> : IFirehoueProRepoOfTPrimaryKey<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        
    }
}
