using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebCourseRepo.Models
{
    public class Topic : Entity
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public int Number { get; set; }

        public double Rating { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(0)]
        public bool Deleted { get; set; }

        public Section Section { get; set; }
     
        public Status? Status { get; set; }
  
        public TopicType Type { get; set; }
        
    }
}
