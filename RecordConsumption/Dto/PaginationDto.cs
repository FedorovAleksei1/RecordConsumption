using System.Collections.Generic;

namespace RecordConsumption.Dto
{
    public class PaginationDto<T>
    {
        public List<T> Elements { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
