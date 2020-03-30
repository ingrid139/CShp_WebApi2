using LojaServices.Api.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LojaServices.Api.Models
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<PromocaoProduto> PromocoesProduto { get; set; }

        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        {

        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=LojaServicesTestes;User Id =sa;Password=Ing@2020;Trusted_Connection=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompraConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new PromocaoProdutoConfiguration());
        }
    }
}