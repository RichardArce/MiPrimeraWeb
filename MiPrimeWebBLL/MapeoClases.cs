using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraWebBLL
{
    public class MapeoClases : Profile
    {
        public MapeoClases()
        {
            CreateMap<MiPrimeraWebDAL.Entidades.Carro, MiPrimeraWebBLL.Dtos.CarroDto>().ReverseMap();
        }
    }
}
