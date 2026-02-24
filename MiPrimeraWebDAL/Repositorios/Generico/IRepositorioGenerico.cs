using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebDAL.Repositorios.Generico
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<T> ObtenerPorIdAsync(int id);
        Task<List<T>> ObtenerTodosAsync();
        void AgregarAsync(T entidad);
        void ActualizarAsync(T entidad);
        void EliminarAsync(int id);



        //Confirmación
        Task<bool> GuardarCambiosAsync(); //SavesChanges, se puede usar para confirmar los cambios en la base de datos, es decir, para guardar los cambios realizados en las operaciones CRUD. El método devuelve un booleano que indica si los cambios se guardaron correctamente o no.


    }
}
