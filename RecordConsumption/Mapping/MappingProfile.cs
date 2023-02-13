using AutoMapper;
using Domain.Models;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Dto.Polyclinic;
using RecordConsumption.Dto.Practice;
using RecordConsumption.Dto.Specialization;
using RecordConsumption.Dto.Town;

namespace RecordConsumption.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Town, TownDto>();

            CreateMap<TownDto, Town>();

            CreateMap<Doctor, DoctorDto>();

            CreateMap<DoctorDto, Doctor>();

            CreateMap<DoctorEditDto, Doctor>();

            CreateMap<Polyclinic, PolyclinicDto>();

            CreateMap<PolyclinicDto, Polyclinic>();

            CreateMap<Specialization, SpecializationDto>();

            CreateMap<SpecializationDto, Specialization>();

            CreateMap<PracticeEditDto, Practice>()
                .ForMember(t => t.Id, rep => rep.MapFrom(ped => ped.Id == null ? 0 : ped.Id));
        }
    }
}
