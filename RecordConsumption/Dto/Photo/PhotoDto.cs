using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordConsumption.Dto.Photo
{
    public class PhotoDto
    {
        public int Id { get; set; }

        public string NameFile { get; set; }

        public string Base64 { get; set; }
    }
}
