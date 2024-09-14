using ControleEstacionamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamento.Controllers
{
    public class EstacionamentoController : Controller
    {
        private EstacionamentoService _service;

        public EstacionamentoController(EstacionamentoService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarEntrada(String placa, DateTime entrada)
        {
            _service.CadastrarEntradaVeiculo(entrada, placa);

            return RedirectToAction("Index");           
        }
        [HttpPost]
        public ActionResult CadastrarSaida(String placa, DateTime saida)
        {
            _service.CadastrarSaidaVeiculo(saida, placa);

            return RedirectToAction("Index");
        }


    }
}
