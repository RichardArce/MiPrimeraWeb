using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebBLL
{
    public static class Constantes
    {

        public static class Carro
        {
            public const string Null = "El objeto carro no puede ser nulo.";
            public const string InvalidId = "El id del carro no puede ser 0.";
            public const string NoActualizarToyota = "No se pueden actualizar carros marca toyota";
            public const string ErrorActualizar = "Error al actualizar el carro en la base de datos.";
            public const string ErrorGuardar = "Error al guardar el carro en la base de datos.";
            public const string ErrorEliminar = "Error al eliminar el carro en la base de datos.";
            public const string NotFound = "El carro no existe, debe ingresarlo en el modulo...";
        }


    }
}
