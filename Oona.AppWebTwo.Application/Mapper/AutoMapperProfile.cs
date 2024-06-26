using AutoMapper;
using Oona.AppWebTwo.Application.Sevices.CountryServices.ViewModels;
using Oona.AppWebTwo.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Oona.AppWebTwo.Application.Sevices.CountryServices.ViewModels.CountriesViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Oona.AppWebTwo.Application.Mapper
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<CountriesList, Country>().ReverseMap();
            CreateMap<List<CountriesList>,List<Country>>().ReverseMap();


        }
    }
}
