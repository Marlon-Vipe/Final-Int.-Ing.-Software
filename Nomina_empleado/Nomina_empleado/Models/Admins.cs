using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nomina_empleado.Models
{
    public partial class Admins
    {
        public int IdAdmin { get; set; }
        public string Users { get; set; }
        public string Pass { get; set; }
    }
}
