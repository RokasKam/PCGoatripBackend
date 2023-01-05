using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreationDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset ModificationDate { get; }
    }
}
