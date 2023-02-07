using RecordConsumption.Dto.Town;
using System.Collections.Generic;

namespace RecordConsumption.Services.TownService
{
    public interface ITownService
    {
        List<TownDto> GetList();
        TownDto Get(int id);
        void Create(TownDto townDto);
        void Edit(TownDto townDto);
        void Delete(int id);
    }
}
