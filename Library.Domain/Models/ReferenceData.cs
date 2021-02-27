using Versteey.Common.Domain;

namespace Library.Domain.Models
{
    public abstract class ReferenceData : BaseEntity
    {
        public virtual string Code { get; set; }
    }
}
