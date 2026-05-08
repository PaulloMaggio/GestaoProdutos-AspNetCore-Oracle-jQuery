using Microsoft.AspNetCore.Mvc;
using GestaoProdutosOracle.Data;

namespace GestaoProdutosOracle.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly AppDbContext _context;
        public DepartamentosController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult ObterTodos() => Json(_context.Departamentos.OrderBy(d => d.Nome).ToList());
    }
}