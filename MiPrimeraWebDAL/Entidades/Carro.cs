using System;
using System.Collections.Generic;

namespace MiPrimeraWebDAL.Entidades;

public partial class Carro
{
    public int Id { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? FechaRegistro { get; set; }
}
