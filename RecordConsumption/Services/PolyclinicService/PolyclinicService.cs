using AutoMapper;
using Domain.Models;
using Domain;
using RecordConsumption.Dto.Specialization;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecordConsumption.Dto.Polyclinic;

namespace RecordConsumption.Services.PolyclinicService
{
    public class PolyclinicService : IPolyclinicService
    {
        private readonly RecordConsumptionDbContext _context;
        private readonly IMapper _mapper;
        public PolyclinicService(RecordConsumptionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public List<PolyclinicDto> GetList()
        {
            var polyclinics = _context.Polyclinics.Include(p => p.Photos).ToList();
            var polyclinicsDto = _mapper.Map<List<PolyclinicDto>>(polyclinics);
            return polyclinicsDto;
        }

        public PolyclinicDto Get(int id)
        {
            var polyclinicDto = new PolyclinicDto();
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var polyclinic = _context.Polyclinics.FirstOrDefault(t => t.Id == id);

            if (polyclinic == null)
                throw new Exception("Объект не найден");

            polyclinicDto = _mapper.Map<PolyclinicDto>(polyclinic);

            return polyclinicDto;
        }

        public void Create(PolyclinicDto polyclinicDto)
        {
            if (polyclinicDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(polyclinicDto.Name))
                throw new Exception("Наименование не может быть пустым");

            var polyclinic = _mapper.Map<Polyclinic>(polyclinicDto);

            _context.Polyclinics.Add(polyclinic);
            _context.SaveChanges();
        }

        public void Edit(PolyclinicDto polyclinicDto)
        {
            if (polyclinicDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(polyclinicDto.Name))
                throw new Exception("Наименование не может быть пустым");


            var photos = _context.Polyclinics.AsNoTracking().Where(p => p.Id == polyclinicDto.Id).Select(p => p.Photos)
                .FirstOrDefault();

            var polyclinic = _mapper.Map<Polyclinic>(polyclinicDto);
            _context.Polyclinics.Update(polyclinic);
            var removePhotos = photos.Where(p => !polyclinic.Photos.Any(r => r.Id == p.Id)).ToList();
            _context.Photos.RemoveRange(removePhotos);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var polyclinic = _context.Polyclinics.FirstOrDefault(t => t.Id == id);

            if (polyclinic == null)
                throw new Exception("Объект не найден");

            // проверить нет ли врачей
            //if (specialization.Count > 0) 
            //    throw new Exception("Список полеклиник не пуст. Удалите или измените полеклиники");???

            _context.Polyclinics.Remove(polyclinic);
            _context.SaveChanges();


        }
    }
}
