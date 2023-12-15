using AutoMapper;
using Nobeseed.Application.Dtos;
using Nobeseed.Domain.Entities;

namespace Nobeseed.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDto, Book>();
        }
    }
}
