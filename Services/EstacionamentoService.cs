using ControleEstacionamento.DAO;
using ControleEstacionamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ControleEstacionamento.Services
{
    public class EstacionamentoService
    {
        private readonly ControleEstacionamentoContext? _context;
        private readonly ValorService? _valorService;

        public EstacionamentoService(ControleEstacionamentoContext context, ValorService valorService)
        {
            _context = context;
            _valorService = valorService;
        }

        public bool CadastrarEntradaVeiculo(DateTime horarioChegada, String placa)
        {
            var veiculo = new Veiculo
            {
                HorarioChegada = horarioChegada,
                Placa = placa,
                Valor = _valorService.GetVigenciaByData(horarioChegada)
            };
            _context.Add(veiculo);
            _context.SaveChanges();
            return true;

        }

        public List<Veiculo> GetVeiculos()
        {
            return _context.Veiculos
                .Include(v=> v.Valor)
                .ToList();
        }

        public List<Veiculo> GetVeiculoByPlaca(String placa)
        {
            var veiculos = _context.Veiculos
            .Where(veiculo => veiculo.Placa.ToLower().Equals(placa.ToLower()) && veiculo.HorarioSaida.Equals(DateTime.MinValue))
            .ToList();
            return veiculos;
        }

        public Veiculo CadastrarSaidaVeiculo(DateTime horarioSaida, string placa)
        {
            List<Veiculo> veiculos = GetVeiculoByPlaca(placa);
            if (veiculos.Count > 0)
            {
                Veiculo veiculo = veiculos.First();
                veiculo.HorarioSaida = horarioSaida;

                TimeSpan duracao = veiculo.HorarioSaida - veiculo.HorarioChegada;
                int horas = duracao.Hours;
                int minutos = (int)duracao.TotalMinutes;

                if (horas == 0 && minutos <= 30)
                {
                    veiculo.Desconto = 0.50;
                }
                else
                {
                    veiculo.Desconto = 1;
                }

                int adicionalMinutos = horas * 10;
                minutos = minutos - adicionalMinutos;

                veiculo.Tempo = minutos / 60;
                if (minutos % 60 != 0)
                {
                    veiculo.Tempo += 1;
                }

                _context.Update(veiculo);
                _context.SaveChanges();

                return veiculo;
            }
            return null;
        }



    }
}
