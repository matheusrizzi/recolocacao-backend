using Microsoft.EntityFrameworkCore;
using recolocacao.Dominio.Entidades;

namespace recolocacao.Infra.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }

        public DbSet<Erro> Erros { get; set; }
        public DbSet<Usuario> Usuarios;
        public DbSet<Candidato> Candidatos;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Candidato>();
            modelBuilder.Entity<Erro>();

        }
    }
}