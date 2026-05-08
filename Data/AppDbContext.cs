using Microsoft.EntityFrameworkCore;
using GestaoProdutosOracle.Models;

namespace GestaoProdutosOracle.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().ToTable("DEPARTAMENTOS");
            modelBuilder.Entity<Produto>().ToTable("PRODUTOS");

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Departamento)
                .WithMany(d => d.Produtos)
                .HasForeignKey(p => p.DepartamentoId);
        }
    }
}