using System;
using System.Collections.Generic;

#nullable disable

namespace Nomina_empleado.Models
{
    public partial class Vacation
    {
        public int IdVacations { get; set; }
        public string IdentificationCard { get; set; }
        public DateTime? FromVacations { get; set; }
        public DateTime? ToVacations { get; set; }
        public bool? StatusVacation { get; set; }
    }
}
