using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebDAL.Repositorios.Carro
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private List<Entidades.Carro> carros = new List<Entidades.Carro>()
        {
            new Entidades.Carro() { Id = 1, Marca = "Toyota", Modelo = "Corolla" },
            new Entidades.Carro() { Id = 2, Marca = "Honda", Modelo = "Civic" },
            new Entidades.Carro() { Id = 3, Marca = "Ford", Modelo = "Focus" }
        };

        //private readonly MiPrimeraWebContext _context;


        public void ActualizarCarro(Entidades.Carro carro)
        {

            var index = carros.FindIndex(c => c.Id == carro.Id);

            // Update the stored entity (only Marca and Modelo in this model)
            carros[index].Marca = carro.Marca;
            carros[index].Modelo = carro.Modelo;
        }

        public void AgregarCarro(Entidades.Carro carro)
        {

            // Generate new Id (simple in-memory auto-increment)
            var newId = carros.Any() ? carros.Max(c => c.Id) + 1 : 1;

            // Add a copy to avoid external references modifying internal list
            carros.Add(new Entidades.Carro
            {
                Id = newId,
                Marca = carro.Marca,
                Modelo = carro.Modelo
            });
        }
        

        public void EliminarCarro(int id)
        {
            var removed = carros.RemoveAll(c => c.Id == id);

        }

        public Entidades.Carro ObtenerCarroPorId(int id)
        {
            var found = carros.FirstOrDefault(c => c.Id == id);
            if (found == null) return null;

            // Return a copy to avoid exposing internal list items
            return new Entidades.Carro
            {
                Id = found.Id,
                Marca = found.Marca,
                Modelo = found.Modelo
            };
        }

        public List<Entidades.Carro> ObtenerCarros()
        {
            return carros
               .Select(c => new Entidades.Carro { Id = c.Id, Marca = c.Marca, Modelo = c.Modelo })
               .ToList();
        }
    }
}
