namespace GestaoProdutosOracle.Models.DTOs
{
    public class ProdutoInputDTO
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int DepartamentoId { get; set; }
    }
}