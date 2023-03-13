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
        public List<DoctorDto> AdminDoctorGetList()
        {
            var doctorDtoList = _doctorService.GetList();
            return doctorDtoList;
        }


        [HttpGet]
        public DoctorEditDto AdminDoctorGet(int id)
        {
            var doctorDto = _doctorService.GetForEdit(id);
            return doctorDto;
        }


        [HttpPost]
        public int AdminDoctorCreate([FromBody] DoctorEditDto doctor)
        {
            return _doctorService.Create(doctor);
        }

        [HttpPost]
        public void AdminDoctorEdit([FromBody] DoctorEditDto doctor)
        {
            _doctorService.Edit(doctor);
            return;
        }

        [HttpDelete]
        public void AdminDoctorDelete(int id)
        {
            _doctorService.Delete(id);
            return;
        }
    }
}
