using Domain.Abstraction;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.DataBaseRepositoryes
{
    public class EmployeeRepository : IReposiroryBase<Employee, Guid>
    {
        public readonly ApplicationContext _contextEmployee;

        public EmployeeRepository(ApplicationContext contextEmployee)
        {
            _contextEmployee = contextEmployee;
        }

        public async Task<Guid> AddEmployee(Employee entity)
        {
            await _contextEmployee.Employees.AddAsync(entity);
            await _contextEmployee.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<ICollection<Employee>> GetByDepartment(Guid departmentId)
        {
            return await _contextEmployee.Employees
                .Where(e => e.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<ICollection<Employee>> GetByLeader(Guid leaderId)
        {
            return await _contextEmployee.Employees
                .Where(e => e.LeaderId == leaderId)
                .ToListAsync();
        }
    }
}
