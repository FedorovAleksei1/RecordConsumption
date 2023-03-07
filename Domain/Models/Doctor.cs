using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string LongDesk { get; set; }
        public string ShortDesk { get; set; }
        public ICollection<Practice> Practices { get; set; }
        public ICollection<Polyclinic> Polyclinics { get; set; }
    }
}
