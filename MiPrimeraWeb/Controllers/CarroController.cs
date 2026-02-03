using Microsoft.AspNetCore.Mvc;
using MiPrimeraWebBLL.Dtos;
using MiPrimeraWebBLL.Servicios.Carro;
using MiPrimeraWebDAL.Repositorios.Carro;

namespace MiPrimeraWeb.Controllers
{
    public class CarroController : Controller
    {
        private readonly ICarroServicio _carroServicio; //Como soluciono esto?   //DEPENDENCIA


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
            return Json(response);
        }

        public async Task<IActionResult> AgregarCarro(CarroDto carro)// Model Binding //Bind es Viejo // BindNever no se usa por que se evoluciono a los DTOS(informacion optima para mostrar)
        {
            var response = await _carroServicio.AgregarCarroAsync(carro);
            return View(response);
        }

        public async Task<IActionResult> ActualizarCarro(CarroDto carro)
        {
            var response = await _carroServicio.ActualizarCarroAsync(carro);
            return View(response);
        }

        public async Task<IActionResult> EliminarCarro(int id)
        {
            var response = await _carroServicio.EliminarCarroAsync(id);
            return View(response);
        }
    }
}
