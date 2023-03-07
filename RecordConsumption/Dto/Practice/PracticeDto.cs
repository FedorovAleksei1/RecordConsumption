using RecordConsumption.Dto.Doctor;
using RecordConsumption.Dto.Specialization;
using System;

namespace RecordConsumption.Dto.Practice
{
    public class PracticeDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int DoctorId { get; set; }
        public DoctorDto Doctor { get; set; }
        public int SpecializationId { get; set; }
        public SpecializationDto Specialization { get; set; }
    }
}
