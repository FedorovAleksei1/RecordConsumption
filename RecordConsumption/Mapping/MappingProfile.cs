using AutoMapper;
using Domain.Models;
using RecordConsumption.Dto.Town;

namespace RecordConsumption.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Town, TownDto>();
            //.ForMember(t => t.IsZato, rep => rep.Ignore());

            CreateMap<TownDto, Town>();
               

            
        }
    }
}
