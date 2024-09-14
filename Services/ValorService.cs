using ControleEstacionamento.DAO;
using ControleEstacionamento.Models;

namespace ControleEstacionamento.Services
{
    public class ValorService
    {

        private readonly ControleEstacionamentoContext? _context;

        public ValorService(ControleEstacionamentoContext context)
        {
            _context = context;
        }

        public List<Valor> GetValores()
        {
            return _context.valores.ToList();
        }

        public Valor GetVigenciaByData(DateTime data)
        {
            return _context.valores
                .Where(valor => valor.DataInicioVigencia <= data && valor.DataFimVigencia >= data) 
                .First();
        }

        public bool CadastrarValor(DateTime inicio, DateTime fim, Double valor)
        {
            var vigencia = new Valor
            {
                DataInicioVigencia = inicio,
                DataFimVigencia = fim,
                Preco = valor
            };
            _context.Add(vigencia);
            _context.SaveChanges();
            return true;

        }


    }
}
