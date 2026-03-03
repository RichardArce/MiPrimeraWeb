
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MiPrimeraWebBLL.Dtos;
using MiPrimeraWebBLL.Servicios.Carro;
using MiPrimeraWebDAL.Repositorios.Generico;
using MiPrimeraWebDAL.Entidades;
using Moq;
using Xunit;
using MiPrimeraWebBLL;

namespace MiPrimeraWebTest
{
    public class CarroServicioTests
    {
        private readonly Mock<IRepositorioGenerico<Carro>> _repositorioGenerico;
        private readonly Mock<IMapper> _mapper;
        private readonly CarroServicio _carroServicio;

        public CarroServicioTests()
        {
            _repositorioGenerico = new();
            _mapper = new();
            _carroServicio = new CarroServicio(_mapper.Object, _repositorioGenerico.Object);
        }

        [Fact]
        public async Task ActualizarCarroAsync_ReturnsBadRequest_WhenDtoIsNull()
        {
            // Act
            var result = await _carroServicio.ActualizarCarroAsync(null);

            // Assert
            Assert.False(result.esCorrecto);
            Assert.Equal("El objeto carro no puede ser nulo.", result.mensaje);
            Assert.Equal(400, result.codigoStatus);
        }

        [Fact]
        public async Task ActualizarCarroAsync_ReturnsBadRequest_WhenMarcaIsToyota()
        {
            // Arrange
            var dto = new CarroDto { Id = 1, Marca = "Toyota", Modelo = "Corolla" };

            // Act
            var result = await _carroServicio.ActualizarCarroAsync(dto);

            // Assert
            Assert.False(result.esCorrecto);
            Assert.Equal(Constantes.Carro.NoActualizarToyota, result.mensaje);
            Assert.Equal(400, result.codigoStatus);

        }

        [Fact]
        public async Task ActualizarCarroAsync_ReturnsServerError_WhenGuardarFails()
        {
            // Arrange
            var dto = new CarroDto { Id = 2, Marca = "Ford", Modelo = "Fiesta" };
            var entity = new Carro { Id = 2, Marca = "Ford", Modelo = "Fiesta" };

            _mapper.Setup(m => m.Map<Carro>(dto)).Returns(entity);
            _repositorioGenerico.Setup(r => r.GuardarCambiosAsync()).ReturnsAsync(false); // Simula fallo al guardar

            // Act
            var result = await _carroServicio.ActualizarCarroAsync(dto);

            // Assert
            Assert.False(result.esCorrecto);
            Assert.Equal(Constantes.Carro.ErrorActualizar, result.mensaje);
            Assert.Equal(500, result.codigoStatus);
        }

        [Fact]
        public async Task ActualizarCarroAsync_ReturnsSuccess_WhenGuardarSucceeds()
        {
            // Arrange
            var dto = new CarroDto { Id = 3, Marca = "Nissan", Modelo = "Sentra" };
            var entity = new Carro { Id = 3, Marca = "Nissan", Modelo = "Sentra" };

            _mapper.Setup(m => m.Map<Carro>(dto)).Returns(entity);
            _repositorioGenerico.Setup(r => r.GuardarCambiosAsync()).ReturnsAsync(true);

            // Act
            var result = await _carroServicio.ActualizarCarroAsync(dto);

            // Assert - default CustomResponse ctor indicates success
            Assert.True(result.esCorrecto);
            Assert.Equal("Operación realizada correctamente.", result.mensaje);
            Assert.Equal(200, result.codigoStatus);

        }

        [Fact]
        public async Task AgregarCarroAsync_ReturnsBadRequest_WhenDtoIsNull()
        {
            // Act
            var result = await _carroServicio.AgregarCarroAsync(null);

            // Assert
            Assert.False(result.esCorrecto);
            Assert.Equal(Constantes.Carro.Null, result.mensaje);
            Assert.Equal(400, result.codigoStatus);

        }

        [Fact]
        public async Task AgregarCarroAsync_ReturnsServerError_WhenGuardarFails()
        {
            // Arrange
            var dto = new CarroDto { Id = 4, Marca = "Kia", Modelo = "Rio" };
            var entity = new Carro { Id = 4, Marca = "Kia", Modelo = "Rio" };

            _mapper.Setup(m => m.Map<Carro>(dto)).Returns(entity);
            _repositorioGenerico.Setup(r => r.GuardarCambiosAsync()).ReturnsAsync(false);

            // Act
            var result = await _carroServicio.AgregarCarroAsync(dto);

            // Assert
            Assert.False(result.esCorrecto);
            Assert.Equal(Constantes.Carro.ErrorGuardar, result.mensaje);
            Assert.Equal(500, result.codigoStatus);
        }

        [Fact]
        public async Task AgregarCarroAsync_Succeeds_CallsRepository()
        {
            // Arrange
            var dto = new CarroDto { Id = 5, Marca = "Hyundai", Modelo = "i20" };
            var entity = new Carro { Id = 5, Marca = "Hyundai", Modelo = "i20" };

            _mapper.Setup(m => m.Map<Carro>(dto)).Returns(entity);
            _repositorioGenerico.Setup(r => r.GuardarCambiosAsync()).ReturnsAsync(true);

            // Act
            var result = await _carroServicio.AgregarCarroAsync(dto);

            // Assert
            Assert.True(result.esCorrecto);
            Assert.Equal(200, result.codigoStatus);
        }

        [Fact]
        public async Task EliminarCarroAsync_ReturnsBadRequest_WhenIdIsZero()
        {
            // Act
            var result = await _carroServicio.EliminarCarroAsync(0);

            // Assert
            Assert.False(result.esCorrecto);
            Assert.Equal("El objeto carro no puede ser nulo.", result.mensaje);
            Assert.Equal(400, result.codigoStatus);
        }

        [Fact]
        public async Task EliminarCarroAsync_ReturnsServerError_WhenGuardarFails()
        {
            // Arrange
            const int id = 6;
            _repositorioGenerico.Setup(r => r.GuardarCambiosAsync()).ReturnsAsync(false);

            // Act
            var result = await _carroServicio.EliminarCarroAsync(id);

            // Assert
            Assert.False(result.esCorrecto);
            Assert.Equal(Constantes.Carro.ErrorEliminar, result.mensaje);
            Assert.Equal(500, result.codigoStatus);
        }

        [Fact]
        public async Task EliminarCarroAsync_Succeeds_CallsRepository()
        {
            // Arrange
            const int id = 7;
            _repositorioGenerico.Setup(r => r.GuardarCambiosAsync()).ReturnsAsync(true);

            // Act
            var result = await _carroServicio.EliminarCarroAsync(id);

            // Assert
            Assert.True(result.esCorrecto);
            Assert.Equal(200, result.codigoStatus);
        }

        [Fact]
        public async Task ObtenerCarroPorIdAsync_ReturnsNotFound_WhenEntityIsNull()
        {
            // Arrange
            const int id = 8;
            _repositorioGenerico.Setup(r => r.ObtenerPorIdAsync(id)).ReturnsAsync((Carro)null);

            // Act
            var result = await _carroServicio.ObtenerCarroPorIdAsync(id);

            // Assert
            Assert.False(result.esCorrecto);
            Assert.Equal(Constantes.Carro.NotFound, result.mensaje);
            Assert.Equal(404, result.codigoStatus);
        }

        [Fact]
        public async Task ObtenerCarroPorIdAsync_ReturnsMappedDto_WhenEntityExists()
        {
            // Arrange
            const int id = 9;
            var entity = new Carro { Id = id, Marca = "Seat", Modelo = "Ibiza" };
            var dto = new CarroDto { Id = id, Marca = "Seat", Modelo = "Ibiza" };

            _repositorioGenerico.Setup(r => r.ObtenerPorIdAsync(id)).ReturnsAsync(entity);
            _mapper.Setup(m => m.Map<CarroDto>(entity)).Returns(dto);

            // Act
            var result = await _carroServicio.ObtenerCarroPorIdAsync(id);

            // Assert
            Assert.True(result.esCorrecto);
            Assert.Equal(200, result.codigoStatus);
            Assert.NotNull(result.Data);
            Assert.Equal(dto.Id, result.Data.Id);
            Assert.Equal(dto.Marca, result.Data.Marca);
            Assert.Equal(dto.Modelo, result.Data.Modelo);
        }

        [Fact]
        public async Task ObtenerCarrosAsync_ReturnsMappedList()
        {
            // Arrange
            var entities = new List<Carro>
            {
                new Carro { Id = 10, Marca = "BMW", Modelo = "X1" },
                new Carro { Id = 11, Marca = "Audi", Modelo = "A3" }
            };

            var dtos = new List<CarroDto>
            {
                new CarroDto { Id = 10, Marca = "BMW", Modelo = "X1" },
                new CarroDto { Id = 11, Marca = "Audi", Modelo = "A3" }
            };

            _repositorioGenerico.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(entities);
            _mapper.Setup(m => m.Map<List<CarroDto>>(entities)).Returns(dtos);

            // Act
            var result = await _carroServicio.ObtenerCarrosAsync();

            // Assert
            Assert.True(result.esCorrecto);
            Assert.Equal(200, result.codigoStatus);
            Assert.NotNull(result.Data);
            Assert.Equal(2, result.Data.Count);
        }
    }
}