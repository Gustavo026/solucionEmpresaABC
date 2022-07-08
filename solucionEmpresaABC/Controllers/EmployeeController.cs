using solucionEmpresaABC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using solucionEmpresaABC.Models.ViewModels;

namespace solucionEmpresaABC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly dbTestContext _dbContext;

        public EmployeeController(dbTestContext Context)
        {
            _dbContext = Context;
        }

        public async Task<IActionResult> Index()
        {
            var employees=_dbContext.Employees;
            return View(await employees.ToListAsync());
        }


        public IActionResult Create()
        {
            ViewData["areaS"] = new SelectList(_dbContext.Areas, "idArea", "area");
            ViewData["SubareaS"] = new SelectList(_dbContext.Subareas, "idSubarea", "subarea");
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if(ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    NombreEmpleado = model.Name,
                    ApellidoPaterno = model.FirstLastName,
                    ApellidoMaterno = model.SecondLastName,
                    IdArea = model.AreaID,
                    IdSubarea = model.SubareaID,
                    Email = model.email
                };
                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["areaS"] = new SelectList(_dbContext.Areas, "idArea", "area", model.AreaID);
            ViewData["SubareasS"] = new SelectList(_dbContext.Subareas, "idSubarea", "subarea", model.SubareaID);

            return View(model);
        }
    }
}
