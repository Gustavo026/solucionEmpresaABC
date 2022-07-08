using System;
using System.Collections.Generic;

namespace solucionEmpresaABC.Models
{
    public partial class Employee
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public int IdArea { get; set; }
        public int IdSubarea { get; set; }
        public string Email { get; set; } = null!;

        public virtual Area IdAreaNavigation { get; set; } = null!;
    }
}
