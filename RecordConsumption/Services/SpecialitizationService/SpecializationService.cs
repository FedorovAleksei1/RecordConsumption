using AutoMapper;
using Domain.Models;
using Domain;
using RecordConsumption.Dto.Town;
using System.Collections.Generic;
using System;
using RecordConsumption.Dto.Specialization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RecordConsumption.Services.SpecialitizationService
{
    public class SpecializationService : ISpecializationService
    {
        private readonly RecordConsumptionDbContext _context;
        private readonly IMapper _mapper;
        public SpecializationService(RecordConsumptionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

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
    }
}
