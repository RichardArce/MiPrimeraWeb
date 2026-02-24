using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebDAL.Repositorios.Carro
{
    public interface ICarroRepositorio //Cosas especificas de la entidad carro, no es generico, es especifico para el carro, por eso se llama ICarroRepositorio, si fuera generico seria IRepositorioGenerico<T>
    {
        List<Entidades.Carro> ObtenerCarros();
        Entidades.Carro ObtenerCarroPorId(int id);
        bool AgregarCarro(Entidades.Carro carro);
        bool ActualizarCarro(Entidades.Carro carro);
        bool EliminarCarro(int id);

    }
}

//REPOSITORIO GENERICO:
//Es una clase que implementa una interfaz genérica para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en cualquier entidad.
//Permite reutilizar código y reducir la duplicación al manejar diferentes tipos de entidades de manera uniforme.
