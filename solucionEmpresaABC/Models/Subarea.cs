using System;
using System.Collections.Generic;

namespace solucionEmpresaABC.Models
{
    public partial class Subarea
    {
        public int IdSubarea { get; set; }
        public string SubArea1 { get; set; } = null!;
        public int IdArea { get; set; }

        public virtual Area IdAreaNavigation { get; set; } = null!;
    }
}
