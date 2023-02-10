using AutoMapper;
using Domain.Models;
using RecordConsumption.Dto.Practice;
using RecordConsumption.Dto.Town;

namespace RecordConsumption.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Town, TownDto>();

            CreateMap<TownDto, Town>();

            CreateMap<PracticeEditDto, Practice>();
        }
    }
}
