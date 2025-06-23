using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Employee : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }


        public Guid LeaderId { get; set; }
        public Employee? Leader { get; set; }
        public List<Employee> Subordinates { get; set; } = new();

        public DateTime CreatedNote { get; set; }

    }
}
