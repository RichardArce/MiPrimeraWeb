using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebDAL.Entidades
{
    public class Carro
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }


        public DateTime FechaRegistro { get; set; } // CAMPO DE BASE DE DATOS
    }
}
