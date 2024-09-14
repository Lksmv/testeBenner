namespace ControleEstacionamento.Models
{
    public class Valor
    {
        public int Id { get; set; }

        public DateTime DataInicioVigencia { get; set; }

        public DateTime DataFimVigencia { get; set; } = DateTime.MinValue;

        public double Preco { get; set; }
    }
}
