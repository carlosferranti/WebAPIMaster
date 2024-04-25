using Microsoft.EntityFrameworkCore;
using WebAPIMaster.Data.Map;
using WebAPIMaster.Models;

namespace WebAPIMaster.Data
{
    public class TarefasDBContext : DbContext
    {

        public TarefasDBContext(DbContextOptions<TarefasDBContext> options)
            : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<UsuarioModel> TarefasModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
