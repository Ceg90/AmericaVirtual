using System.Collections.Generic;

namespace AmericaVirtual.Model.Entities
{
    public class PaginatedEntities<TEntity> where TEntity : BaseEntity
    {
        public int TotalItems { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
    }
}
