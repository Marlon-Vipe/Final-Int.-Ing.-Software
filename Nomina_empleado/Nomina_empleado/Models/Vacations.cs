using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nomina_empleado.Models
{
    public partial class Vacations
    {
        public int IdVacations { get; set; }
        public string IdentificationCard { get; set; }
        public DateTime? FromVacations { get; set; }
        public DateTime? ToVacations { get; set; }
        public bool? StatusVacation { get; set; }
    }
}
