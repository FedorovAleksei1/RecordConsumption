using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Polyclinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        //Photo

        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Doctor> Doctors { get; set; }

    }
}
