namespace GestaoProdutosOracle.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
    }
}