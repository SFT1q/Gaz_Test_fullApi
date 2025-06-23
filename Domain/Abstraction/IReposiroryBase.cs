using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public interface IReposiroryBase<TEntity, TId> where TEntity : class
    {
        public Task<ICollection<TEntity>> GetByDepartment(Guid departmentId);
        public Task<ICollection<TEntity>> GetByLeader(Guid leaderId);
        public Task<TId> AddEmployee(TEntity entity);
    }
}
