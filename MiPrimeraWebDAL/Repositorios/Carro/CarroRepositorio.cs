using Microsoft.EntityFrameworkCore;
using MiPrimeraWebDAL.Data;
using MiPrimeraWebDAL.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebDAL.Repositorios.Carro
{
    public class CarroRepositorio : ICarroRepositorio
    {


        private readonly MiPrimeraWebDbContext _context;


        public CarroRepositorio(MiPrimeraWebDbContext context)
        {
            _context = context;
        }


        public bool ActualizarCarro(Entidades.Carro carro)
        {

            var existing = _context.Carros.Find(carro.Id); //Buscamos el carro

            // Update only the fields that should change //Actualizamos la informacion
            existing.Marca = carro.Marca;
            existing.Modelo = carro.Modelo;

            _context.Carros.Update(existing); //Actualizar la informacion en el contexto

            // Persist changes
            return _context.SaveChanges() > 0;//confirmamos los cambios // Si se guardo correctamente, SaveChanges devuelve un numero mayor a 0
        }

        public bool AgregarCarro(Entidades.Carro carro)
        {

            throw new NotImplementedException();
        }
        

        public bool EliminarCarro(int id)
        {
            var existing = _context.Carros.Find(id);

            _context.Carros.Remove(existing);
            return _context.SaveChanges() > 0;

        }

        public Entidades.Carro ObtenerCarroPorId(int id)
        {
            var found = _context.Carros
                            .AsNoTracking()
                            .FirstOrDefault(c => c.Id == id);

            // Return a copy to avoid exposing tracked entity
            return new Entidades.Carro
            {
                Id = found.Id,
                Marca = found.Marca,
                Modelo = found.Modelo,
                FechaRegistro = found.FechaRegistro
            };
        }

        public List<Entidades.Carro> ObtenerCarros()
        {
            return _context.Carros
                           .AsNoTracking()
                           .Select(c => new Entidades.Carro { Id = c.Id, Marca = c.Marca, Modelo = c.Modelo, FechaRegistro = c.FechaRegistro })
                           .ToList();
        }
    }
}
