using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STOCTABLE.Domain.Enums;
using STOCTABLE.Domain.Models;

namespace STOCTABLE.Persistence.Context
{
    public class StoctableContext : DbContext
    {
        public StoctableContext(DbContextOptions<StoctableContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set;}
        public DbSet<Fornecedor> Fornecedores { get;set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<ClientePF> ClientePFs { get;set; }
        public DbSet<ClientePJ> ClientePJs { get;set; }
        public DbSet<Transportadora> Transportadoras { get; set; }

        public void Configuration(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(u => u.Unidades).HasConversion(
                u => u.ToString(),
                u => (Unidade)Enum.Parse(typeof(Unidade), u));
        }

    }
}
