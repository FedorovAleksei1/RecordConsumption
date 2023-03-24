using RecordConsumption.Dto;
using RecordConsumption.Dto.Doctor;
using RecordConsumption.Dto.Polyclinic;
using System.Collections.Generic;

namespace RecordConsumption.Services.DoctorService
{
    public interface IDoctorService
    {
        List<DoctorDto> GetList();
        DoctorViewDto GetDoctorById(int id);
        DoctorEditDto GetForEdit(int id);
        int Create(DoctorEditDto doctorDto);
        void Edit(DoctorEditDto doctorDto);
        void Delete(int id);
        PaginationDto<DoctorDto> GetDoctorsBySpecializationId(int id, int page = 1, int take = 5);
    }
}
