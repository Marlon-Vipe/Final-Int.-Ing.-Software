using System;
using System.Collections.Generic;

#nullable disable

namespace Nomina_empleado.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Payrolls = new HashSet<Payroll>();
        }

        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string IdentificationCard { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string RoleEmployee { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? Salary { get; set; }

        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}
