using Microsoft.AspNetCore.Mvc;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Dto.Town;
using RecordConsumption.Services.DoctorService;
using RecordConsumption.Services.TownService;
using System.Collections.Generic;

namespace RecordConsumption.Controllers.Admin
{

    [ApiController]

    [Route("api/[controller]/[action]")]
    public class AdminDoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public AdminDoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public List<DoctorDto> GetList()
        {
            var doctorDtoList = _doctorService.GetList();
            return doctorDtoList;
        }


        [HttpGet]
        public DoctorEditDto Get(int id)
        {
            var doctorDto = _doctorService.Get(id);
            return doctorDto;
        }


        [HttpPost]
        public int Create([FromBody] DoctorEditDto doctor)
        {
            return _doctorService.Create(doctor);
        }

        [HttpPost]
        public void Edit([FromBody] DoctorEditDto doctor)
        {
            _doctorService.Edit(doctor);
            return;
        }

        [HttpPost]
        public void Delete(int id)
        {
            _doctorService.Delete(id);
            return;
        }
    }
}
