using System.ComponentModel.DataAnnotations;
using WebCourseRepo.Models;

namespace WebCourseRepo.Dtos
{
    public class TopicDto
    {
        public int? Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public double Rating { get; set; }
        public bool Deleted { get; set; }
    }
}
