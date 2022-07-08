using solucionEmpresaABC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace solucionEmpresaABC.Controllers
{
    public class SubareaController: Controller
    {
        private readonly dbTestContext _dbTestContext;
        
        public SubareaController(dbTestContext context)
        {
            _dbTestContext = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbTestContext.Subareas.ToListAsync());
        }
    }
}
