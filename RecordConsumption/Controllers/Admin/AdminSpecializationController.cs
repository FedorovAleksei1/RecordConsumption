using Microsoft.AspNetCore.Mvc;
using RecordConsumption.Dto.Polyclinic;
using RecordConsumption.Dto.Specialization;
using RecordConsumption.Services.PolyclinicService;
using RecordConsumption.Services.SpecialitizationService;
using System.Collections.Generic;

namespace RecordConsumption.Controllers.Admin
{

    [ApiController]

    [Route("api/[controller]")]
    public class AdminSpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;
        public AdminSpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [HttpGet("[action]")]
        public List<SpecializationDto> GetList()
        {
            var specializationDtoList = _specializationService.GetList();
            return specializationDtoList;
        }


        [HttpGet("[action]/{id}")]
        public SpecializationDto Get(int id)
        {
            var specializationDto = _specializationService.Get(id);
            return specializationDto;
        }


        [HttpPost("[action]")]
        public void Create([FromBody] SpecializationDto specialization)
        {
            _specializationService.Create(specialization);
            return;
        }

        [HttpPost("[action]")]
        public void Edit([FromBody] SpecializationDto specialization)
        {
            _specializationService.Edit(specialization);
            return;
        }

        [HttpPost("[action]/{id}")]
        public void Delete(int id)
        {
            _specializationService.Delete(id);
            return;
        }
    }
}
