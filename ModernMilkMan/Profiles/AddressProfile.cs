using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Entities.Address, Model.AddressDTO>();
            CreateMap<Model.AddressForCreationDTO, Entities.Address>();
            CreateMap<Entities.Address, Model.AddressForUpdateDTO> ();
            CreateMap<Model.AddressForUpdateDTO, Entities.Address>();

        }
    }
}
