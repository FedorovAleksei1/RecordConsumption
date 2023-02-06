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
        public string Name { get; set; }
        public ICollection<Practice> Practices { get; set; }
        public ICollection<Polyclinic> Polyclinics { get; set; }
    }
}
