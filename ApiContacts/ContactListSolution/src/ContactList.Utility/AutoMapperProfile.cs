using AutoMapper;
using ContactList.DTOs;
using ContactList.Model;

namespace ContactList.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contact, ContactDTOs>().ReverseMap();

        }
    }
}
