using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCourseRepo.Models
{
    public abstract class Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
