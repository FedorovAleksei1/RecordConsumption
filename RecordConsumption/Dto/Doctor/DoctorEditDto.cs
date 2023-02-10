using RecordConsumption.Dto.Practice;
using System.Collections.Generic;

namespace RecordConsumption.Dto.Doctor
{
    public class DoctorEditDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> PolyclinicsId { get; set; }
        public List<PracticeEditDto> Practices { get; set; }
    }
}
