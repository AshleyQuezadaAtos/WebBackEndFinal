using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebCourseRepo.Models
{
    public class TopicFeedback : Entity
    {
        [Required]
        public string Feedback { get; set; }
        [Required]
        public Topic Topic { get; set; }
        //[Required]
        //public ICollection<Topics> Topics { get; set; }
    }
}
