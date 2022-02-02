using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCourseRepo.Models
{
    public class Course : Entity
    {

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string? Description { get; set; } 

        public double? Duration { get; set; }    
        
        public double? Rating { get; set; }

        public bool Deleted { get; set; }


        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",  ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        [Required] 
        public Status Status { get; set; }

    }
}
