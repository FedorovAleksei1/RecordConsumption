using AutoMapper;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Connections.Features;
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

            var practicesDd = _context.Practices.Where(p => p.DoctorId == practicesDto.FirstOrDefault().DoctorId).ToList();

            practices.Where(p => p.Id == 0).ToList().ForEach(p =>
            {
                _context.Practices.Add(p);
            });

            practices.Where(p => p.Id != 0).ToList().ForEach(p =>
            {
                
                var element = practicesDd.Where(pDb => pDb.Id == p.Id).FirstOrDefault();
                element.Start = p.Start;
                element.End = p.End;
                _context.Practices.Update(element);
            });

            _context.RemoveRange(practicesDd
                .Where(pDd => 
                practices.Select(p => p.Id).Contains(pDd.Id)
           ).FirstOrDefault());

            _context.SaveChanges();
        }
    }   
}
