using System.ComponentModel.DataAnnotations;



namespace solucionEmpresaABC.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string FirstLastName { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        public string? SecondLastName { get; set; }

        [Required]
        [Display(Name = "Área")]
        public int AreaID { get; set; }

        [Required]
        [Display(Name = "Subárea")]
        public int SubareaID { get; set; }

        [Required]
        [Display(Name = "Correo Electrónico")]
        public string email { get; set; }
        
    }
}
