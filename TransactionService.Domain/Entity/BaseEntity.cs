using System.ComponentModel.DataAnnotations;

namespace TransactionService.Domain
{
    public abstract class BaseEntity<TId> : IEntity<TId>
    {
        #region entity members
        [Key]
        public TId Id { get; set; }
        [MaxLength(200)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } =  DateTime.UtcNow;
        public virtual bool IsDeleted { get; set; } = false;
        [MaxLength(200)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public BaseEntity()
        {

        }
        public BaseEntity(TId id)
        {
            Id = id;
        }
        #endregion
    }
}