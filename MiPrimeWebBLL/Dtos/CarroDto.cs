using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //Import Para utilizar validaciones

namespace MiPrimeraWebBLL.Dtos
{
    public class CarroDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")] // @DataAnnotations 
        public string Marca { get; set; }
        [Required(ErrorMessage = "La modelo es obligatorio")]
        public string Modelo { get; set; }
    }
}
