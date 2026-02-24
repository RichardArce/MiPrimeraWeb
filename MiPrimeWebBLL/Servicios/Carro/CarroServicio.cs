using AutoMapper;
using MiPrimeraWebBLL.Dtos;
using MiPrimeraWebDAL.Repositorios.Carro;
using MiPrimeraWebDAL.Repositorios.Generico;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebBLL.Servicios.Carro
{
    public class CarroServicio : ICarroServicio
    {
        private readonly ICarroRepositorio _carroRepositorio;
        private readonly IMapper _mapper;
        private readonly IRepositorioGenerico<MiPrimeraWebDAL.Entidades.Carro> _repositorioGenerico;
        public CarroServicio(ICarroRepositorio carroRepositorio, IMapper mapper, IRepositorioGenerico<MiPrimeraWebDAL.Entidades.Carro> repositorioGenerico)
        {
            _carroRepositorio = carroRepositorio;
            _mapper = mapper;
            _repositorioGenerico = repositorioGenerico;
        }


        public async Task<CustomResponse<CarroDto>> ActualizarCarroAsync(CarroDto carroDto)
        {
            var response  = new CustomResponse<CarroDto>();

            //CUANDO PASO LAS VALIDACIONES O REGLA DE NEGOCIO, PUEDE EJECUTAR EL PROCESO NORMALMENTE

            if (carroDto is null) //Validaciones
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

            //Que pasa si la base de datos nos response incorrecto
            var carroActualiza = _mapper.Map<MiPrimeraWebDAL.Entidades.Carro>(carroDto);
            if (!_carroRepositorio.ActualizarCarro(carroActualiza))
            {     
                response.esCorrecto = false;
                response.mensaje = "Error al actualizar el carro en la base de datos.";
                response.codigoStatus = 500; // Internal Server Error
                return response;
            }

            


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
            if (!_carroRepositorio.AgregarCarro(carroGuardar))
            {
                response.esCorrecto = false;
                response.mensaje = "Error al actualizar el carro en la base de datos.";
                response.codigoStatus = 500; // Internal Server Error
                return response;
            }


            


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


            _repositorioGenerico.EliminarAsync(id);

            if (! await _repositorioGenerico.GuardarCambiosAsync())
            {
                response.esCorrecto = false;
                response.mensaje = "Error al actualizar el carro en la base de datos.";
                response.codigoStatus = 500; // Internal Server Error
                return response;
            }

            return response;
        }

        public async Task<CustomResponse<CarroDto>> ObtenerCarroPorIdAsync(int id)
        {
            var response = new CustomResponse<CarroDto>();

            var carro = _carroRepositorio.ObtenerCarroPorId(id);

            if(carro is null)
            {
                response.esCorrecto = false;
                response.mensaje = "El carro no existe, debe ingresarlo en el modulo..."; //IMPORTANTE
                response.codigoStatus = 404; // Not Found
                return response;
            }


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
