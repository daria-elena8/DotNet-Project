using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetProjectAPI.Models.Base
{
    public class BaseEntity: IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
