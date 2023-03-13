using Microsoft.AspNetCore.Mvc;
using RecordConsumption.Dto.Town;
using RecordConsumption.Services.TownService;
using System.Collections.Generic;

namespace RecordConsumption.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AdminTownController : ControllerBase
    {
        private readonly ITownService _townService;
        public AdminTownController(ITownService townService)
        {
            _townService = townService;
        }

        [HttpGet]
        public List<TownDto> AdminTownGetList()
        {
            var townDtoList = _townService.GetList();
            return townDtoList;
        }


        [HttpGet]
        public TownDto AdminTownGet(int id)
        {
            var townDto = _townService.Get(id);
            return townDto;
        }


        [HttpPost]
        public void AdminTownCreate([FromBody] TownDto town)
        {
            _townService.Create(town);
            return;
        }

        [HttpPost]
        public void AdminTownEdit([FromBody] TownDto town)
        {
            _townService.Edit(town);
            return;
        }

        [HttpDelete]
        public void AdminTownDelete(int id)
        {
            _townService.Delete(id);
            return;
        }
    }
}
