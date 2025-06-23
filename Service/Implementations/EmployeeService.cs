using Domain.Abstraction;
using Domain.Entity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IReposiroryBase<Employee, Guid> _repository;

        public EmployeeService(IReposiroryBase<Employee, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> AddEmployee(Employee employee)
        {
            employee.CreatedNote = DateTime.Now;
            return await _repository.AddEmployee(employee);
        }

        public async Task<ICollection<Employee>> GetEmployeesByDepartment(Guid departmentId)
        {
            return await _repository.GetByDepartment(departmentId);
        }

        public async Task<ICollection<Employee>> GetEmployeesByLeader(Guid leaderId)
        {
            return await _repository.GetByLeader(leaderId);
        }
    }
}
