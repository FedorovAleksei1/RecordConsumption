using RecordConsumption.Dto.Photo;
using System.Collections.Generic;

namespace RecordConsumption.Dto.Polyclinic
{
    public class PolyclinicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public int TownId { get; set; }
        public List<PhotoDto> Photos { get; set; }

        //Photo

        //Photo
    }
}
