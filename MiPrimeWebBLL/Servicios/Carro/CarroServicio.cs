using AutoMapper;
using MiPrimeraWebBLL.Dtos;
using MiPrimeraWebDAL.Repositorios.Carro;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebBLL.Servicios.Carro
{
    public class CarroServicio : ICarroServicio
    {
        private readonly ICarroRepositorio _carroRepositorio;
        private readonly IMapper _mapper;

        public CarroServicio(ICarroRepositorio carroRepositorio, IMapper mapper)
        {
            _carroRepositorio = carroRepositorio;
            _mapper = mapper;
        }


        public async Task<CustomResponse<CarroDto>> ActualizarCarroAsync(CarroDto carroDto)
        {
            var response  = new CustomResponse<CarroDto>();

            if(carroDto is null) //Validaciones
            {
                response.esCorrecto = false;
                response.mensaje = "El objeto carro no puede ser nulo.";
                response.codigoStatus = 400; // Bad Request
                return response;
            }
            if(carroDto.Marca == "Toyota") //Regla de negocio ejemplo // CASOS DE PRUEBA
            {
                response.esCorrecto = false;
                response.mensaje = "No se pueden actualizar carros marca toyota";
                response.codigoStatus = 400; // Bad Request
                return response;
            }

            //CUANDO PASO LAS VALIDACIONES O REGLA DE NEGOCIO, PUEDE EJECUTAR EL PROCESO NORMALMENTE

            var carroActualiza = _mapper.Map<MiPrimeraWebDAL.Entidades.Carro>(carroDto);
            _carroRepositorio.ActualizarCarro(carroActualiza);


            return response;

        }

        public async Task<CustomResponse<CarroDto>> AgregarCarroAsync(CarroDto carroDto)
        {
            var response = new CustomResponse<CarroDto>();

            //Validaciones
            if (carroDto is null)
            {
                response.esCorrecto = false;
                response.mensaje = "El objeto carro no puede ser nulo.";
                response.codigoStatus = 400; // Bad Request
                return response;
            }


            //Proceso
            var carroGuardar = _mapper.Map<MiPrimeraWebDAL.Entidades.Carro>(carroDto);
            _carroRepositorio.AgregarCarro(carroGuardar);


            return response;

        }

        public async Task<CustomResponse<CarroDto>> EliminarCarroAsync(int id)
        {
            var response = new CustomResponse<CarroDto>();

            //Validaciones
            if (id is 0)
            {
                response.esCorrecto = false;
                response.mensaje = "El objeto carro no puede ser nulo.";
                response.codigoStatus = 400; // Bad Request
                return response;
            }


            //Proceso   
            _carroRepositorio.EliminarCarro(id);
            return response;
        }

        public async Task<CustomResponse<CarroDto>> ObtenerCarroPorIdAsync(int id)
        {
            var response = new CustomResponse<CarroDto>();
            response.Data = _mapper.Map<CarroDto>(_carroRepositorio.ObtenerCarroPorId(id));
            return response;
        }

        public async Task<CustomResponse<List<CarroDto>>> ObtenerCarrosAsync()
        {
            var response = new CustomResponse<List<CarroDto>>();
            response.Data = _mapper.Map<List<CarroDto>>(_carroRepositorio.ObtenerCarros());
            return response;
        }
    }
}
