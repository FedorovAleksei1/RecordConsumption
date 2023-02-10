using AutoMapper;
using Domain;
using Domain.Models;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Dto.Practice;
using System.Collections.Generic;
using System.Linq;

namespace RecordConsumption.Services.PracticeService
{
    public class PracticeService : IPracticeService
    {
        private readonly RecordConsumptionDbContext _context;
        private readonly IMapper _mapper;
        public PracticeService(RecordConsumptionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateRange(List<PracticeEditDto> practicesDto) 
        {
            if (practicesDto == null || practicesDto.Count == 0)
                return;

            var practices = _mapper.Map<List<Practice>>(practicesDto);

            _context.Practices.AddRange(practices);
            _context.SaveChanges();
        }

        public void EditRange(List<PracticeEditDto> practicesDto)
        {
            if (practicesDto == null || practicesDto.Count == 0)
                return;

            var practices = _mapper.Map<List<Practice>>(practicesDto);

            var bd = _context.Practices.Where(p => p.DoctorId == practicesDto.FirstOrDefault().DoctorId).ToList();

            //Если нет в БД, и есть в новом списке, то добавить
            _context.Practices.AddRange(practices);

            //Если есть в БД, и есть в новом списке, то изминить

            //Если есть в БД, и нет в новом списке, то удалить


            _context.SaveChanges();
        }
    }   
}
