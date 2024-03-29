﻿using AutoMapper;
using Domain.Models;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Dto.Photo;
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

            CreateMap<DoctorDto, Doctor>();
            CreateMap<Doctor, DoctorDto>()
                 .ForMember(t => t.PhotoBase64, rep => rep.MapFrom(ped => ped.PhotoId != null ? ped.Photo.Base64 : ""));
            CreateMap<Doctor, DoctorViewDto>();

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

            CreateMap<Photo, PhotoDto>().ReverseMap();

            CreateMap<PhotoDto, Photo>().ReverseMap();
        }
    }
}
