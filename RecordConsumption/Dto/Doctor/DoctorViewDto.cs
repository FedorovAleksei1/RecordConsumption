using RecordConsumption.Dto.Photo;
using RecordConsumption.Dto.Practice;
using System.Collections.Generic;

namespace RecordConsumption.Dto.Doctor
{
    public class DoctorViewDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string LongDesk { get; set; }
        public string ShortDesk { get; set; }
        public PhotoDto Photo { get; set; }
        public List<PracticeEditDto> PracticesDto { get; set; }
    }
}
