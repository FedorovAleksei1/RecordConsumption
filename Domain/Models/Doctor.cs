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
        public string Phone { get; set; }
        public string LongDesk { get; set; }
        public string ShortDesk { get; set; }
        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }
        public ICollection<Practice> Practices { get; set; }
    }
}
