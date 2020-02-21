using System.Collections.Generic;

namespace Api.Core.Model.DTOs
{
    public class PageResult<TDto> where TDto : BaseDto
    {
        public int TotalItems { get; set; }
        public IEnumerable<TDto> Items { get; set; }
    }
}
