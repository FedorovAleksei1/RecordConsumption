using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecordConsumption.Dto;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Services.DoctorService;
using System.Collections.Generic;

namespace RecordConsumption.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public PaginationDto<DoctorDto> GetDoctorsBySpecializationId(int id, int page = 1, int take = 5)
        {
            return _doctorService.GetDoctorsBySpecializationId(id, page, take);
        }

        [HttpGet]
        public DoctorViewDto GetDoctorById(int id)
        {
            return _doctorService.GetDoctorById(id);
        }
    }
}
