using Microsoft.AspNetCore.Mvc;
using RecordConsumption.Dto.Town;
using RecordConsumption.Services.TownService;
using System.Collections.Generic;

namespace RecordConsumption.Controllers.Admin
{
    [ApiController]

    [Route("api/[controller]")]
    public class AdminTownController : ControllerBase
    {
        private readonly ITownService _townService;
        public AdminTownController(ITownService townService)
        {
            _townService = townService;
        }

        [HttpGet("[action]")]
        public List<TownDto> GetList()
        {
            var townDtoList = _townService.GetList();
            return townDtoList;
        }


        [HttpGet("[action]/{id}")]
        public TownDto Get(int id)
        {
            var townDto = _townService.Get(id);
            return townDto;
        }


        [HttpPost("[action]")]
        public void Create([FromBody] TownDto town)
        {
            _townService.Create(town);
            return;
        }

        [HttpPost("[action]")]
        public void Edit([FromBody] TownDto town)
        {
            _townService.Edit(town);
            return;
        }

        [HttpPost("[action]/{id}")]
        public void Delete(int id)
        {
            _townService.Delete(id);
            return;
        }
    }
}
