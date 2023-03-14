using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Practice
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int Price { get; set; }
        //public DateTime? ExperienceTime { get => { return Start; } }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public int PolyclinicId { get; set; }
        public Polyclinic Polyclinic { get; set; }

    }
}
