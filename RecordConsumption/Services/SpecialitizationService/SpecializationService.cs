using AutoMapper;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RecordConsumption.Dto.Specialization;
using RecordConsumption.Services.PracticeService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecordConsumption.Services.SpecialitizationService
{
    public class SpecializationService : ISpecializationService
    {
        private readonly RecordConsumptionDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPracticeService _practiceService;
        public SpecializationService(RecordConsumptionDbContext context, IMapper mapper, IPracticeService practiceService)
        {
            _context = context;
            _mapper = mapper;
            _practiceService = practiceService;
        }

        public List<SpecializationDto> GetList()
        {
            var specializations = _context.Specializations.ToList();
            var specializationsDto = _mapper.Map<List<SpecializationDto>>(specializations);
            return specializationsDto;

        }

        public SpecializationDto Get(int id)
        {
            var specializationDto = new SpecializationDto();
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var specialization = _context.Specializations.FirstOrDefault(t => t.Id == id);

            if (specialization == null)
                throw new Exception("Объект не найден");

            specializationDto = _mapper.Map<SpecializationDto>(specialization);

            return specializationDto;
        }

        public void Create(SpecializationDto specializationDto)
        {
            if (specializationDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(specializationDto.Name))
                throw new Exception("Наименование не может быть пустым");

            var specialization = _mapper.Map<Specialization>(specializationDto);

            _context.Specializations.Add(specialization);
            _context.SaveChanges();
        }

        public void Edit(SpecializationDto specializationDto)
        {
            if (specializationDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(specializationDto.Name))
                throw new Exception("Наименование не может быть пустым");

            var specialization = _mapper.Map<Specialization>(specializationDto);
            _context.Specializations.Update(specialization);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var specialization = _context.Specializations
                .Include(t => t.Practices)
                .FirstOrDefault(t => t.Id == id);

            if (specialization == null)
                throw new Exception("Объект не найден");

            _context.Practices.RemoveRange(specialization.Practices);
            _context.Specializations.Remove(specialization);

            _context.SaveChanges();
        }

        /// <summary>
        /// Список специализации и количество врачей 
        /// </summary>
        /// <param name="town"> фильтр по городу</param>
        /// <returns></returns>
        public List<SpecailizationWithDoctorsDto> GetSpecializationWithDoctors(string town)
        {
            var specializations = new List<SpecailizationWithDoctorsDto>();
            var practices = _practiceService.GetActualPracriceList(town);
            var groupingPractices = practices.GroupBy(t => t.SpecializationId).ToList();
            foreach (var group in groupingPractices)
            {
                specializations.Add(new SpecailizationWithDoctorsDto
                {
                    Id = group.Key,
                    Name = group.Select(s => s.Specialization.Name).FirstOrDefault(),
                    DoctorsCount = group.GroupBy(g => g.DoctorId).Count()
                });
            }
            return specializations;
        }

        /// <summary>
        /// Список специализации для конкретного врача 
        /// </summary>
        /// <param name="ids">Список айди специализации</param>
        /// <returns></returns>
        public List<SpecializationDto> GetSpecializationsByIds(List<int> ids)
        {
            var specializationsDto = new List<SpecializationDto>();
            if (ids != null && ids.Count > 0)
            {
                var specializations = _context.Specializations.Where(x => ids.Contains(x.Id)).ToList();
                specializationsDto = _mapper.Map<List<SpecializationDto>>(specializations);
            }

            return specializationsDto;
        }
    }
}
