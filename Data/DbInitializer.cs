using GestaoProdutosOracle.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoProdutosOracle.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.ExecuteSqlRaw("DELETE FROM \"PRODUTOS\"");
            context.Database.ExecuteSqlRaw("DELETE FROM \"DEPARTAMENTOS\"");

            var depHardware = new Departamento { Nome = "Hardware e Periféricos" };
            var depMecanica = new Departamento { Nome = "Oficina e Performance" };
            var depGames = new Departamento { Nome = "PC Gamer & Consoles" };

            context.Departamentos.AddRange(depHardware, depMecanica, depGames);
            context.SaveChanges();

            var produtos = new List<Produto>
            {
                new Produto { Nome = "Teclado Mecânico RGB", Preco = 250.00m, DepartamentoId = depHardware.Id },
                new Produto { Nome = "Mouse Gamer 12000 DPI", Preco = 180.50m, DepartamentoId = depHardware.Id },
                new Produto { Nome = "Monitor 24' Full HD", Preco = 980.00m, DepartamentoId = depHardware.Id },

                new Produto { Nome = "Filtro de Ar Esportivo", Preco = 120.00m, DepartamentoId = depMecanica.Id },
                new Produto { Nome = "Jogo de Velas Iridium", Preco = 210.00m, DepartamentoId = depMecanica.Id },
                new Produto { Nome = "Óleo Sintético 5W30", Preco = 65.00m, DepartamentoId = depMecanica.Id },
                new Produto { Nome = "Scanner OBD2 Bluetooth", Preco = 150.00m, DepartamentoId = depMecanica.Id },

                new Produto { Nome = "Cadeira Gamer Ergonômica", Preco = 1200.00m, DepartamentoId = depGames.Id },
                new Produto { Nome = "Headset 7.1 Wireless", Preco = 450.00m, DepartamentoId = depGames.Id },
                new Produto { Nome = "Controle Xbox Series S/X", Preco = 399.00m, DepartamentoId = depGames.Id }
            };

            context.Produtos.AddRange(produtos);
            context.SaveChanges();
        }
    }
}