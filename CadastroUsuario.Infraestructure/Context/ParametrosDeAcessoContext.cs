using CadastroUsuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infraestructure.Context
{
    public class ParametrosDeAcessoContext : DbContext
    {
        public ParametrosDeAcessoContext(DbContextOptions options) : base(options) { }

        public DbSet<ParametrosDeAcessoEntity> UsuarioEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
