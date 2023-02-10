using RecordConsumption.Dto.Polyclinic;
using RecordConsumption.Dto.Specialization;
using System.Collections.Generic;

namespace RecordConsumption.Services.PolyclinicService
{
    public interface IPolyclinicService
    {
        List<PolyclinicDto> GetList();
        PolyclinicDto Get(int id);
        void Create(PolyclinicDto polyclinicDto);
        void Edit(PolyclinicDto polyclinicDto);
        void Delete(int id);
    }
}
