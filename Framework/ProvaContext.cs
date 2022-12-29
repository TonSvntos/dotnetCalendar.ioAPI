using Microsoft.EntityFrameworkCore;
using Framework;
using Entities;

namespace Framework.Context
{
    public class ProvaContext : DbContext
    {
        public ProvaContext(DbContextOptions<ProvaContext> options)
            : base(options)
        { }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
