using CadastroUsuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infraestructure.Context
{
    public class CadastroUsuarioContext : DbContext
    {
        public CadastroUsuarioContext(DbContextOptions options) : base(options) { }

        public DbSet<UsuarioEntity> UsuarioEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
