using Microsoft.EntityFrameworkCore;
using OrdemServico.Domain.Entities;

namespace OrdemServico.Infra.Database.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> option) : base(option) { }
        public DbSet<Setor> Setores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
