using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebDAL.Repositorios.Carro
{
    public interface ICarroRepositorio
    {
        List<Entidades.Carro> ObtenerCarros();
        Entidades.Carro ObtenerCarroPorId(int id);
        void AgregarCarro(Entidades.Carro carro);
        void ActualizarCarro(Entidades.Carro carro);
        void EliminarCarro(int id);

    }
}
