using Microsoft.EntityFrameworkCore;
using WebAPIMaster.Data.Map;
using WebAPIMaster.Models;

namespace WebAPIMaster.Data
{
    public class UsuariosDBContext : DbContext
    {
        public UsuariosDBContext(DbContextOptions<UsuariosDBContext> options)
        : base(options)
        { 
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}