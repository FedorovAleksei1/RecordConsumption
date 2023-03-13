using System;

namespace RecordConsumption.Dto.Practice
{
    public class PracticeEditDto
    {
        public int? Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int? DoctorId { get; set; }
        public int SpecializationId { get; set; }
        public int PolyclinicId { get; set; }

    }
}
