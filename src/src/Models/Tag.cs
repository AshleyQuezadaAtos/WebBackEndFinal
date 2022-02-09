using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebCourseRepo.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Tag : Entity
    {
       
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        
        public int Popularity { get; set; }

        public Status? Status { get; set; }

        public int? Priority { get; set; }

        public IList<Course> Courses { get; set; }
    }
}
