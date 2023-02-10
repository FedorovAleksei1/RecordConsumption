using AutoMapper;
using Domain.Models;
using Domain;
using RecordConsumption.Dto.Polyclinic;
using System.Collections.Generic;
using System;
using System.Linq;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Services.PracticeService;

namespace RecordConsumption.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly RecordConsumptionDbContext _context;
        private readonly IPracticeService _practiceService;
        private readonly IMapper _mapper;

        public DoctorService(RecordConsumptionDbContext context, IPracticeService practiceService, IMapper mapper)
        {
            _context = context;
            _practiceService = practiceService;
            _mapper = mapper;

        }

        public List<DoctorDto> GetList()
        {
            var doctors = _context.Doctors.ToList();
            var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);
            return doctorsDto;

        }

        public DoctorDto Get(int id)
        {
            var doctorDto = new DoctorDto();
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var doctor = _context.Doctors.FirstOrDefault(t => t.Id == id);

            if (doctor == null)
                throw new Exception("Объект не найден");

            doctorDto = _mapper.Map<DoctorDto>(doctor);

            return doctorDto;
        }

        public int Create(DoctorEditDto doctorDto)
        {
            if (doctorDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(doctorDto.Name))
                throw new Exception("Наименование не может быть пустым");

            if (doctorDto.Practices == null || doctorDto.Practices.Count == 0)
                throw new Exception("Укажите практику");

            if (doctorDto.PolyclinicsId.Any())
                throw new Exception("Укажите полеклиники");


            var doctor = _mapper.Map<Doctor>(doctorDto);

            doctor.Polyclinics = _context.Polyclinics.Where(p => doctorDto.PolyclinicsId.Contains(p.Id)).ToList();

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            doctorDto.Practices.ForEach(p => p.DoctorId = doctor.Id);
            _practiceService.CreateRange(doctorDto.Practices);

            return doctor.Id;
        }

        public void Edit(DoctorEditDto doctorDto)
        {
            if (doctorDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(doctorDto.Name))
                throw new Exception("Наименование не может быть пустым");

            if (doctorDto.Practices == null || doctorDto.Practices.Count == 0)
                throw new Exception("Верни практику ");

            var doctor = _mapper.Map<Doctor>(doctorDto);


            _context.Doctors.Update(doctor);
            _context.SaveChanges();

            doctorDto.Practices.ForEach(p => p.DoctorId = doctor.Id);
            _practiceService.CreateRange(doctorDto.Practices);//переделать
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var doctor = _context.Doctors.FirstOrDefault(t => t.Id == id);

            if (doctor == null)
                throw new Exception("Объект не найден");

            //if (specialization.Count > 0)
            //    throw new Exception("Список полеклиник не пуст. Удалите или измените полеклиники");???

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();


        }
    }
}