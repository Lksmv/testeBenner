using ControleEstacionamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamento.Controllers
{
    public class ValorController : Controller
    {

        private ValorService _service;

        public ValorController(ValorService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult CadastrarValor(DateTime inicio, DateTime fim, Double valor)
        {
            _service.CadastrarValor(inicio,fim,valor);

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
