using AutoMapper;
using Domain.Models;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Dto.Polyclinic;
using RecordConsumption.Dto.Practice;
using RecordConsumption.Dto.Specialization;
using RecordConsumption.Dto.Town;
using System.Linq;

namespace RecordConsumption.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Town, TownDto>().ReverseMap();

            CreateMap<Doctor, DoctorDto>().ReverseMap();

            CreateMap<Doctor, DoctorEditDto>();

            CreateMap<DoctorEditDto, Doctor>();

            CreateMap<Polyclinic, PolyclinicDto>().ReverseMap();

            CreateMap<PolyclinicDto, Polyclinic>().ReverseMap();

            CreateMap<Specialization, SpecializationDto>();

            CreateMap<SpecializationDto, Specialization>();

            CreateMap<PracticeEditDto, Practice>()
                .ForMember(t => t.Id, rep => rep.MapFrom(ped => ped.Id == null ? 0 : ped.Id));
            CreateMap<Practice, PracticeEditDto>();

            CreateMap<Practice, PracticeDto>().ReverseMap();
        }
    }
}
