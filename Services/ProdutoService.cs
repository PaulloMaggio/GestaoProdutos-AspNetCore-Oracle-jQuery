using Microsoft.EntityFrameworkCore;
using GestaoProdutosOracle.Data;
using GestaoProdutosOracle.Models;
using GestaoProdutosOracle.Models.DTOs;

namespace GestaoProdutosOracle.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoDTO>> ListarTodosAsync()
        {
            return await _context.Produtos
                .AsNoTracking()
                .Include(p => p.Departamento)
                .Select(p => new ProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    PrecoFormatado = p.Preco.ToString("C2"),
                    DepartamentoNome = p.Departamento != null ? p.Departamento.Nome : "N/A"
                })
                .ToListAsync();
        }

        public async Task<bool> CriarProdutoAsync(ProdutoInputDTO dto)
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                DepartamentoId = dto.DepartamentoId
            };

            _context.Produtos.Add(produto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExcluirProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}