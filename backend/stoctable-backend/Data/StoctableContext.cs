using Microsoft.EntityFrameworkCore;
using stoctable_backend.Models;

namespace stoctable_backend.Data
{
    public class StoctableContext : DbContext
    {
        public StoctableContext(DbContextOptions<StoctableContext> options) 
            : base(options)
        {
        }

        public DbSet<Produtos> Produtos { get; set; }
    }
}
