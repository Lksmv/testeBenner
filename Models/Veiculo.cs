namespace ControleEstacionamento.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string? Placa { get; set; }

        public DateTime HorarioChegada { get; set; }

        public DateTime HorarioSaida { get; set; } = DateTime.MinValue;

        public int Tempo { get; set; }

        public Valor Valor {  get; set; }

        public double Desconto { get; set; }

    }
}
