using System;
using System.Collections.Generic;

#nullable disable

namespace Nomina_empleado.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Users { get; set; }
        public string Pass { get; set; }
    }
}
