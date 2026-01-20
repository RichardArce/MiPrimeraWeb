using MiPrimeraWebBLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebBLL.Servicios.Carro
{
    public interface ICarroServicio
    {
        Task<CustomResponse<List<CarroDto>>> ObtenerCarrosAsync();

        Task<CustomResponse<CarroDto>> ObtenerCarroPorIdAsync(int id);

        Task<CustomResponse<CarroDto>> AgregarCarroAsync(CarroDto carroDto);

        Task<CustomResponse<CarroDto>> ActualizarCarroAsync(CarroDto carroDto);

        Task<CustomResponse<CarroDto>> EliminarCarroAsync(int id);

    }
}
