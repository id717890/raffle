using System;
using System.Linq;
using System.Threading.Tasks;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Interface.Services
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Int64 id);
        Task<long> Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Int64 id);
        Task Delete(TEntity entity);
    }
}