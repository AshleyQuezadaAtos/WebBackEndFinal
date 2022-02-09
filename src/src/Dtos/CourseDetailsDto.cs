using System.ComponentModel.DataAnnotations;
using WebCourseRepo.Models;

namespace WebCourseRepo.Dtos
{
    public class CourseDetailsDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public double Rating { get; set; }
        public bool Deleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public Tag Tags { get; set; }
        public Section Sections { get; set; }

    }
}
