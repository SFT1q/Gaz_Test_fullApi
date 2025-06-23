using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<ICollection<Employee>> GetEmployeesByDepartment(Guid departmentId);
        Task<ICollection<Employee>> GetEmployeesByLeader(Guid leaderId);
        Task<Guid> AddEmployee(Employee employee);
    }
}
