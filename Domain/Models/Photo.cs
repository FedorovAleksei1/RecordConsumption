using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string NameFile { get; set; }

        public Guid FileGuid { get; set; }
    }
}
