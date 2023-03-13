using Microsoft.AspNetCore.Mvc;
using RecordConsumption.Dto.Polyclinic;
using RecordConsumption.Dto.Specialization;
using RecordConsumption.Services.PolyclinicService;
using RecordConsumption.Services.SpecialitizationService;
using System.Collections.Generic;

namespace RecordConsumption.Controllers.Admin
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AdminSpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;
        public AdminSpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [HttpGet]
        public List<SpecializationDto> AdminSpecializationGetList()
        {
            var specializationDtoList = _specializationService.GetList();
            return specializationDtoList;
        }


        [HttpGet]
        public SpecializationDto AdminSpecializationGet(int id)
        {
            var specializationDto = _specializationService.Get(id);
            return specializationDto;
        }


        [HttpPost]
        public void AdminSpecializationCreate([FromBody] SpecializationDto specialization)
        {
            _specializationService.Create(specialization);
            return;
        }

        [HttpPost]
        public void AdminSpecializationEdit([FromBody] SpecializationDto specialization)
        {
            _specializationService.Edit(specialization);
            return;
        }

        [HttpDelete]
        public void AdminSpecializationDelete(int id)
        {
            _specializationService.Delete(id);
            return;
        }
    }
}
