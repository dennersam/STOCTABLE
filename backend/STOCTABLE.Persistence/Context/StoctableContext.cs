using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STOCTABLE.Domain.Enums;
using STOCTABLE.Domain.Identity;
using STOCTABLE.Domain.Models;

namespace STOCTABLE.Persistence.Context
{
    public class StoctableContext : IdentityDbContext<User, Role, int,
                                                        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                        IdentityRoleClaim<int>, IdentityUserToken<int>>
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
            builder.Property(u => u.Unidade).HasConversion(
                u => u.ToString(),
                u => (Unidade)Enum.Parse(typeof(Unidade), u));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>( userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                            .WithMany(r => r.UserRoles)
                            .HasForeignKey(ur => ur.RoleId)
                            .IsRequired();

                userRole.HasOne(ur => ur.User)
                            .WithMany(r => r.UserRoles)
                            .HasForeignKey(ur => ur.UserId)
                            .IsRequired();
            });
        }

    }
}
