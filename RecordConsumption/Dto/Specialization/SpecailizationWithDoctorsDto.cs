using RecordConsumption.Dto.Doctor;
using System.Collections.Generic;

namespace RecordConsumption.Dto.Specialization
{
    public class SpecailizationWithDoctorsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public int? DoctorsCount { get; set; }
    }
}
