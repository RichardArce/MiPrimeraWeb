using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebDAL.Repositorios.Carro
{
    public interface ICarroRepositorio
    {
        List<Entidades.Carro> ObtenerCarros();
        Entidades.Carro ObtenerCarroPorId(int id);
        bool AgregarCarro(Entidades.Carro carro);
        bool ActualizarCarro(Entidades.Carro carro);
        bool EliminarCarro(int id);

    }
}
