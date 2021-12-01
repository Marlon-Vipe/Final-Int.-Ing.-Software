using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nomina_empleado.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Payroll = new HashSet<Payroll>();
        }

        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string IdentificationCard { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string RoleEmployee { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? HireDate { get; set; }

        public virtual ICollection<Payroll> Payroll { get; set; }
    }
}
