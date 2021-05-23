using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Profiles
{
    public class CustomerProfile :Profile
    {
        public CustomerProfile()
        {
            CreateMap<Entities.Customer, Model.CustomerDTO>();
            CreateMap<Model.CustomerForCreationDTO, Entities.Customer>();
            CreateMap<Model.CustomerForUpdateDTO, Entities.Customer>();
            CreateMap<Entities.Customer, Model.CustomerForUpdateDTO>();
        }
    }
}
