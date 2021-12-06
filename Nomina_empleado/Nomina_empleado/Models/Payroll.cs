using System;
using System.Collections.Generic;

#nullable disable

namespace Nomina_empleado.Models
{
    public partial class Payroll
    {
        public int Id { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? DatePayroll { get; set; }
        public decimal? Afp { get; set; }
        public decimal? Secure { get; set; }
        public int? NetIncome { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
