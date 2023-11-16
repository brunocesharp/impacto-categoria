using ImpactoManager.Application.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ImpactoManager.Application.Data.Modeling
{
    public class ImpactoPapelariaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Categoria> Categorias { get; set; }

        public ImpactoPapelariaDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ServerVersion.AutoDetect(_configuration.GetConnectionString("ImpactoDb")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetCategoriaTable(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SetCategoriaTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                        .ToTable("Categoria")
                        .Property(x => x.Codigo)
                        .HasColumnName("Codigo");

            modelBuilder.Entity<Categoria>()
                        .ToTable("Categoria")
                        .Property(x => x.Descricao)
                        .HasColumnName("Descricao");

            modelBuilder.Entity<Categoria>().HasKey(x => x.Codigo);
        }
    }
}
