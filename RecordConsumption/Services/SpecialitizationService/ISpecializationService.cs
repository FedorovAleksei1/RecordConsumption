using RecordConsumption.Dto.Specialization;
using RecordConsumption.Dto.Town;
using System.Collections.Generic;

namespace RecordConsumption.Services.SpecialitizationService
{
    public interface ISpecializationService
    {
        List<SpecializationDto> GetList();
        SpecializationDto Get(int id);
        void Create(SpecializationDto specializationDto);
        void Edit(SpecializationDto specializationDto);
        void Delete(int id);
        List<SpecailizationWithDoctorsDto> GetSpecializationWithDoctors(string town);
        List<SpecializationDto> GetSpecializationsByIds(List<int> ids);
    }
}
