using System.ComponentModel.DataAnnotations;

namespace CampShoping.Domiain.Entities.Base
{
    public abstract class BaseEntity
    {

        [Key]
        public int Id { get; set; }
    }
}