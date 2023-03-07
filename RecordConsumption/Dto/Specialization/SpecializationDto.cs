using RecordConsumption.Dto.Doctor;
using System.Collections.Generic;

namespace RecordConsumption.Dto.Specialization
{
    public class SpecializationDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<DoctorDto> Doctors { get; set; }
    }
}
