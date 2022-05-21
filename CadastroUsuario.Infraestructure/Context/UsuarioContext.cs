using CadastroUsuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infraestructure.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions options) : base(options) { }

        public DbSet<UsuarioEntity> UsuarioEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
