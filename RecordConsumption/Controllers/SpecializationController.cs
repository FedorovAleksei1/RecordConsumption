using Microsoft.AspNetCore.Mvc;
using RecordConsumption.Dto.Specialization;
using RecordConsumption.Services.SpecialitizationService;
using System.Collections.Generic;

namespace RecordConsumption.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;
        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [HttpGet("[action]")]
        public List<SpecailizationWithDoctorsDto> GetList(string town)
        {
            return _specializationService.GetSpecializationWithDoctors(town);
        }
    }
}
