using solucionEmpresaABC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace solucionEmpresaABC.Controllers
{
    public class AreaController : Controller
    {

        private readonly dbTestContext _dbTestContext;

        public AreaController(dbTestContext context)
        {
            _dbTestContext = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbTestContext.Areas.ToListAsync());
        }
    }
}
