using GestaoProdutosOracle.Models.DTOs;

namespace GestaoProdutosOracle.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> ListarTodosAsync();
        Task<bool> CriarProdutoAsync(ProdutoInputDTO dto);
        Task<bool> ExcluirProdutoAsync(int id);
    }
}