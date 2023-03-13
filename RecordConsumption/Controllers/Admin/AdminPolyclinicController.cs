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
    [Route("api/[controller]/[action]")]
    public class AdminPolyclinicController : ControllerBase
    {
        private readonly IPolyclinicService _polyclinicService;
        public AdminPolyclinicController(IPolyclinicService polyclinicService)
        {
            _polyclinicService = polyclinicService;
        }

        [HttpGet]
        public List<PolyclinicDto> AdminPolyclinicGetList()
        {
            var polyclinicDtoList = _polyclinicService.GetList();
            return polyclinicDtoList;
        }


        [HttpGet]
        public PolyclinicDto AdminPolyclinicGet(int id)
        {
            var polyclinicDto = _polyclinicService.Get(id);
            return polyclinicDto;
        }


        [HttpPost]
        public void AdminPolyclinicCreate([FromBody] PolyclinicDto polyclinic)
        {
            _polyclinicService.Create(polyclinic);
            return;
        }

        [HttpPost]
        public void AdminPolyclinicEdit([FromBody] PolyclinicDto polyclinic)
        {
            _polyclinicService.Edit(polyclinic);
            return;
        }

        [HttpDelete]
        public void AdminPolyclinicDelete(int id)
        {
            _polyclinicService.Delete(id);
            return;
        }
    }
}
