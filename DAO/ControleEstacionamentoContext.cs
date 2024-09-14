using ControleEstacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstacionamento.DAO
{
    public class ControleEstacionamentoContext : DbContext
    {
        public ControleEstacionamentoContext(DbContextOptions<ControleEstacionamentoContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Valor> valores { get; set; }

    }
}
