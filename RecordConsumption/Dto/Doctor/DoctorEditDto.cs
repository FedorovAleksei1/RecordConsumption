using RecordConsumption.Dto.Practice;
using RecordConsumption.Dto.Specialization;
using System.Collections.Generic;

namespace RecordConsumption.Dto.Doctor
{
    public class DoctorEditDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string LongDesk { get; set; }
        public string ShortDesk { get; set; }
        public List<PracticeEditDto> PracticesDto { get; set; }
    }
}
