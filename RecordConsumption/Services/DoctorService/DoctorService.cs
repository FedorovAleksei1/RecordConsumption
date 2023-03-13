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
using RecordConsumption.Services.SpecialitizationService;

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
            var doctors = _context.Doctors.ToList();
            var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);
            return doctorsDto;

        }

        public DoctorEditDto GetForEdit(int id)
        {
            var doctorDto = new DoctorEditDto();
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var doctor = _context.Doctors
                .Include(d => d.Practices)
                .FirstOrDefault(t => t.Id == id);

            if (doctor == null)
                throw new Exception("Объект не найден");

            var specializationIds = doctor.Practices.Select(x => x.SpecializationId).ToList();
            var specializationsDto = _specializationService.GetSpecializationsByIds(specializationIds);

            doctorDto = _mapper.Map<DoctorEditDto>(doctor);

            return doctorDto;
        }

        public int Create(DoctorEditDto doctorDto)
        {
            if (doctorDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(doctorDto.FirstName ))
                throw new Exception("Наименование не может быть пустым");

            if (string.IsNullOrEmpty( doctorDto.MiddleName ))
                throw new Exception("Наименование не может быть пустым");

            if (string.IsNullOrEmpty( doctorDto.LastName))
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

            var doctor = _context.Doctors.FirstOrDefault(t => t.Id == id);

            if (doctor == null)
                throw new Exception("Объект не найден");

            _context.Practices.RemoveRange(doctor.Practices);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public List<DoctorDto> GetDoctorsBySpecializationId(int id, int page = 1, int take = 5)
        {
            var doctors = _context.Doctors
                .Include(x => x.Practices)
                .OrderBy(d => d.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .ToList();
            var actualDoctors = doctors.SelectMany(x => x.Practices).Where(x => x.SpecializationId == id && x.End == null).Select(x => x.Doctor).ToList();  
            return _mapper.Map<List<DoctorDto>>(actualDoctors);
        }
    }
}