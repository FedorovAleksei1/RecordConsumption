using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using RecordConsumption.Dto.Polyclinic;
using RecordConsumption.Dto.Specialization;
using RecordConsumption.Dto.Town;
using RecordConsumption.Services.PolyclinicService;
using RecordConsumption.Services.TownService;
using System.Collections.Generic;

namespace RecordConsumption.Controllers.Admin
{

    [ApiController]

    [Route("api/[controller]")]
    public class AdminPolyclinicController : ControllerBase
    {
        private readonly IPolyclinicService _polyclinicService;
        public AdminPolyclinicController(IPolyclinicService polyclinicService)
        {
            _polyclinicService = polyclinicService;
        }

        [HttpGet("[action]")]
        public List<PolyclinicDto> GetList()
        {
            var polyclinicDtoList = _polyclinicService.GetList();
            return polyclinicDtoList;
        }


        [HttpGet("[action]/{id}")]
        public PolyclinicDto Get(int id)
        {
            var polyclinicDto = _polyclinicService.Get(id);
            return polyclinicDto;
        }


        [HttpPost("[action]")]
        public void Create([FromBody] PolyclinicDto polyclinic)
        {
            _polyclinicService.Create(polyclinic);
            return;
        }

        [HttpPost("[action]")]
        public void Edit([FromBody] PolyclinicDto polyclinic)
        {
            _polyclinicService.Edit(polyclinic);
            return;
        }

        [HttpPost("[action]/{id}")]
        public void Delete(int id)
        {
            _polyclinicService.Delete(id);
            return;
        }
    }
}
