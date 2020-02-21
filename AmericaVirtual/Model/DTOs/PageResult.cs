using System.Collections.Generic;

namespace AmericaVirtual.Model.DTOs
{
    public class PageResult<TDto> where TDto : BaseDto
    {
        public int TotalItems { get; set; }
        public IEnumerable<TDto> Items { get; set; }
    }
}
