using Microsoft.AspNetCore.Mvc;
using MiPrimeraWebBLL.Dtos;
using MiPrimeraWebBLL.Servicios.Carro;

namespace MiPrimeraWeb.Controllers
{
    public class CarroController : Controller
    {
        private readonly ICarroServicio _carroServicio;


        public CarroController(ICarroServicio carroServicio)
        {
            _carroServicio = carroServicio;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ObtenerCarros()
        {
            var response = await _carroServicio.ObtenerCarrosAsync();
            return View(response);
        }

        public async Task<IActionResult> AgregarCarro(CarroDto carro)
        {
            var response = await _carroServicio.AgregarCarroAsync(carro);
            return View(response);
        }
    }
}
