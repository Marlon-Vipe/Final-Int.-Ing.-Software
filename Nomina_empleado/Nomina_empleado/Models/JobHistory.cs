using System;
using System.Collections.Generic;

#nullable disable

namespace Nomina_empleado.Models
{
    public partial class JobHistory
    {
        public int IdJobHistory { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string NameEmployee { get; set; }
        public string IdentificationCard { get; set; }
        public string RoleEmployee { get; set; }
    }
}
