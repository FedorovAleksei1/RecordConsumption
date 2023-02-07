using AutoMapper;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RecordConsumption.Dto.Town;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecordConsumption.Services.TownService
{
    public class TownService : ITownService
    {

        private readonly RecordConsumptionDbContext _context;
        private readonly IMapper _mapper;
        public TownService(RecordConsumptionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public List<TownDto> GetList()
        {
            var towns = _context.Towns.ToList();
            var townsDto = _mapper.Map<List<TownDto>>(towns);
            return townsDto;

        }

        public TownDto Get(int id)
        {
            var townDto = new TownDto();
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var town = _context.Towns.FirstOrDefault(t => t.Id == id);

            if (town == null)
                throw new Exception("Объект не найден");

            townDto = _mapper.Map<TownDto>(town);

            return townDto;
        }

        public void Create(TownDto townDto)
        {
            if (townDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(townDto.Name))
                throw new Exception("Наименование не может быть пустым");

            var town = _mapper.Map<Town>(townDto);

            _context.Towns.Add(town);
            _context.SaveChanges();
        }

        public void Edit(TownDto townDto)
        {
            if (townDto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(townDto.Name))
                throw new Exception("Наименование не может быть пустым");

            var town = _mapper.Map<Town>(townDto);
            _context.Towns.Update(town);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var town = _context.Towns.Include(t => t.Polyclinics).FirstOrDefault(t => t.Id == id);

            if (town == null)
                throw new Exception("Объект не найден");

            if (town.Polyclinics.Count > 0)
                throw new Exception("Список полеклиник не пуст. Удалите или измените полеклиники");

            _context.Towns.Remove(town);
            _context.SaveChanges();


        }
    }
}
