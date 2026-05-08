using Microsoft.AspNetCore.Mvc;
using GestaoProdutosOracle.Services;
using GestaoProdutosOracle.Models.DTOs;

namespace GestaoProdutosOracle.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _service.ListarTodosAsync();
            return Json(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ProdutoInputDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var sucesso = await _service.CriarProdutoAsync(dto);
            if (!sucesso) return StatusCode(500);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            var sucesso = await _service.ExcluirProdutoAsync(id);
            if (!sucesso) return NotFound();

            return Ok();
        }
    }
}