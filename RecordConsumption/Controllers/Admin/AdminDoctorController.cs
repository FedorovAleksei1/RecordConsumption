using Microsoft.AspNetCore.Mvc;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Dto.Town;
using RecordConsumption.Services.DoctorService;
using RecordConsumption.Services.TownService;
using System.Collections.Generic;

namespace RecordConsumption.Controllers.Admin
{

    [ApiController]

    [Route("api/[controller]")]
    public class AdminDoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public AdminDoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("[action]")]
        public List<DoctorDto> GetList()
        {
            var doctorDtoList = _doctorService.GetList();
            return doctorDtoList;
        }


        [HttpGet("[action]/{id}")]
        public DoctorDto Get(int id)
        {
            var doctorDto = _doctorService.Get(id);
            return doctorDto;
        }


        [HttpPost("[action]")]
        public int Create([FromBody] DoctorEditDto town)
        {
            return _doctorService.Create(town);
        }

        [HttpPost("[action]")]
        public void Edit([FromBody] DoctorEditDto town)
        {
            _doctorService.Edit(town);
            return;
        }

        [HttpPost("[action]/{id}")]
        public void Delete(int id)
        {
            _doctorService.Delete(id);
            return;
        }
    }
}
