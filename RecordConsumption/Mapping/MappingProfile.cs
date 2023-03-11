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

            CreateMap<DoctorEditDto, Doctor>();

            CreateMap<Doctor, DoctorEditDto>();
                //.ForMember(t => t.PracticesDto, rep => rep.MapFrom(ped => ped.Practices))
                //.ForMember(t => t.PolyclinicsId, rep => rep.MapFrom(ped => ped.Polyclinics.Select(p => p.Id).ToList())); 

            CreateMap<Polyclinic, PolyclinicDto>().ReverseMap();

            CreateMap<Specialization, SpecializationDto>();

            CreateMap<SpecializationDto, Specialization>();

            CreateMap<PracticeEditDto, Practice>()
                .ForMember(t => t.Id, rep => rep.MapFrom(ped => ped.Id == null ? 0 : ped.Id));
            CreateMap<Practice, PracticeEditDto>();

            CreateMap<Practice, PracticeDto>().ReverseMap();
        }
    }
}
