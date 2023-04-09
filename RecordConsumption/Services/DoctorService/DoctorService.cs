using AutoMapper;
using Domain.Models;
using Domain;
using RecordConsumption.Dto.Polyclinic;
using System.Collections.Generic;
using System;
using System.Linq;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Services.PracticeService;
using Microsoft.EntityFrameworkCore;
using RecordConsumption.Dto.Photo;
using RecordConsumption.Dto.Practice;
using RecordConsumption.Services.SpecialitizationService;
using System.Numerics;
using RecordConsumption.Dto;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;

namespace RecordConsumption.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly RecordConsumptionDbContext _context;
        private readonly IPracticeService _practiceService;
        private readonly ISpecializationService _specializationService;
        private readonly IMapper _mapper;

        public DoctorService(RecordConsumptionDbContext context, IPracticeService practiceService, IMapper mapper, ISpecializationService specializationService)
        {
            _context = context;
            _practiceService = practiceService;
            _mapper = mapper;
            _specializationService = specializationService;
        }

        public List<DoctorDto> GetList()
        {
            var doctors = _context.Doctors.Include(d => d.Photo).ToList();
            var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);
            return doctorsDto;

        }

        public DoctorViewDto GetDoctorById(int id)
        {
            var doctorDto = new DoctorViewDto();
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var doctor = _context.Doctors
                .FirstOrDefault(t => t.Id == id);

            if (doctor == null)
                throw new Exception("Объект не найден");

            doctorDto = _mapper.Map<DoctorViewDto>(doctor);
            doctorDto.PracticesDto = _mapper.Map<List<PracticeEditDto>>(_context.Practices.Where(p => p.DoctorId == doctor.Id).ToList());
            doctorDto.Photo = _mapper.Map<PhotoDto>(_context.Photos.Where(p => p.Id == doctor.PhotoId).FirstOrDefault());

            return doctorDto;
        } 

        public DoctorEditDto GetForEdit(int id)
        {
            var doctorDto = new DoctorEditDto();
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var doctor = _context.Doctors
                .FirstOrDefault(t => t.Id == id);

            if (doctor == null)
                throw new Exception("Объект не найден");

            doctorDto = _mapper.Map<DoctorEditDto>(doctor);
            doctorDto.PracticesDto = _mapper.Map<List<PracticeEditDto>>(_context.Practices.Where(p => p.DoctorId == doctor.Id).ToList());
            doctorDto.Photo = _mapper.Map<PhotoDto>(_context.Photos.Where(p => p.Id == doctor.PhotoId).FirstOrDefault());

            return doctorDto;
        }

        public int Create(DoctorEditDto doctorDto)
        {
            if (doctorDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(doctorDto.FirstName))
                throw new Exception("Наименование не может быть пустым");

            if (string.IsNullOrEmpty(doctorDto.MiddleName))
                throw new Exception("Наименование не может быть пустым");

            if (string.IsNullOrEmpty(doctorDto.LastName))
                throw new Exception("Наименование не может быть пустым");

            if (doctorDto.PracticesDto == null || doctorDto.PracticesDto.Count == 0)
                throw new Exception("Укажите практику");


            var doctor = _mapper.Map<Doctor>(doctorDto);

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            doctorDto.PracticesDto.ForEach(p => p.DoctorId = doctor.Id);
            _practiceService.CreateRange(doctorDto.PracticesDto);

            return doctor.Id;
        }

        public void Edit(DoctorEditDto doctorDto)
        {
            if (doctorDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(doctorDto.FirstName))
                throw new Exception("Наименование не может быть пустым");

            if (string.IsNullOrEmpty(doctorDto.MiddleName))
                throw new Exception("Наименование не может быть пустым");

            if (string.IsNullOrEmpty(doctorDto.LastName))
                throw new Exception("Наименование не может быть пустым");

            if (doctorDto.PracticesDto == null || doctorDto.PracticesDto.Count == 0)
                throw new Exception("Верни практику ");


            var doctor = _mapper.Map<Doctor>(doctorDto);


            _context.Doctors.Update(doctor);
            _context.SaveChanges();

            doctorDto.PracticesDto.ForEach(p => p.DoctorId = doctor.Id);
            _practiceService.EditRange(doctorDto.PracticesDto);
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var doctor = _context.Doctors.Include(p => p.Practices).FirstOrDefault(t => t.Id == id);

            if (doctor == null)
                throw new Exception("Объект не найден");

            //_context.Practices.RemoveRange(doctor.Practices);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public PaginationDto<DoctorDto> GetDoctorsBySpecializationId(int id, int page, int take)
        {
            var doctors = _context.Doctors
                .Where(d => d.Practices.Any(p => p.SpecializationId == id && p.End == null))
                .Include(d => d.Photo)
                .OrderBy(d => d.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .ToList();
            var paginationDto = new PaginationDto<DoctorDto>();
            paginationDto.Elements = _mapper.Map<List<DoctorDto>>(doctors);
            paginationDto.TotalCount = _context.Doctors
                .Where(d => d.Practices.Any(p => p.SpecializationId == id && p.End == null))
                .Count(); 
            return paginationDto;
        }
    }
}