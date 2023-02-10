using RecordConsumption.Dto.Doctor;
using RecordConsumption.Dto.Polyclinic;
using System.Collections.Generic;

namespace RecordConsumption.Services.DoctorService
{
    public interface IDoctorService
    {
        List<DoctorDto> GetList();
        DoctorDto Get(int id);
        int Create(DoctorEditDto doctorDto);
        void Edit(DoctorEditDto doctorDto);
        void Delete(int id);
    }
}
