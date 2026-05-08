using System.Collections.Generic;

namespace GestaoProdutosOracle.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}