using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodingActivity.WebApiVue.Data;
using CodingActivity.WebApiVue.DTOs;
using CodingActivity.WebApiVue.Entities;

namespace CodingActivity.WebApiVue.Config
{

    public class AutoMappingConfig : Profile
    {
        private readonly CADBContext _context;

        public AutoMappingConfig(CADBContext context)
        {
            this._context = context;

            CreateMap<Contact, ContactDTO>() // means you want to map from Contact to ContactDTO
                 .ForMember(dest =>
                    dest.Address,
                    opt => opt.MapFrom(src => new AddressDTO
                    {
                        City = src.Address.City,
                        StateCode = src.Address.State,
                        State = this._context.State.FirstOrDefault(s => s.Code == src.Address.State).StateName,
                        Street = src.Address.Street,
                        Zip = src.Address.Zip
                    }));

            CreateMap<ContactDTO, Contact>() // means you want to map from ContactDTO to Contact
                 .ForMember(dest =>
                    dest.Address,
                    opt => opt.MapFrom(src => new Address
                    {
                        ContactId = this.TryToConvertToInt(src.Id),
                        City = src.Address.City,
                        State = src.Address.StateCode,
                        Street = src.Address.Street,
                        Zip = src.Address.Zip
                    }));
        }

        private int TryToConvertToInt(string value)
        {
            int result;

            int.TryParse(value, out result);

            return
                result;
        }
    }
}
