using Microsoft.EntityFrameworkCore;

namespace ProjetoModeloDDD.Infra
{
    public class ExemploSimplesDbContext : DbContext
    {
        public ExemploSimplesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=xxx\\myInstanceName;Database=xxx;User Id=xxx;Password=xxx");
        }
    }
}
