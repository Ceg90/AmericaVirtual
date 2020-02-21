using System.Collections.Generic;

namespace Api.Core.Model.Entities
{
    public class PaginatedEntities<TEntity> where TEntity : BaseEntity
    {
        public int TotalItems { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
    }
}
