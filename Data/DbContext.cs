using Microsoft.EntityFrameworkCore;
using MeuPrimeiroProjetoCSharp.Models;

namespace MeuPrimeiroProjetoCSharp.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}