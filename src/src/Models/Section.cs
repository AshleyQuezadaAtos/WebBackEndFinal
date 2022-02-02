using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCourseRepo.Models;

namespace WebCourseRepo.Models
{
    public class Section : Entity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(150)]
        public string? Description { get; set; }
        
        [Required]
        public int Number { get; set; }

        public double? Rating { get; set; }
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(0)]
        public bool Deleted { get; set; }

        public Course Course { get; set; }

        public Status? Status { get; set; }

      

    }
}
