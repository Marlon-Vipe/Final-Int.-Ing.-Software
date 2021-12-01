using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nomina_empleado.Models
{
    public partial class Payroll
    {
        public int Id { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? DatePayroll { get; set; }
        public decimal? Afp { get; set; }
        public decimal? Secure { get; set; }
        public decimal? Commission { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
