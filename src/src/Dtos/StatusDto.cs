using System.ComponentModel.DataAnnotations;
using WebCourseRepo.Models;

namespace WebCourseRepo.Dtos
{
    public class StatusDto
    {
        public int? Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

       
    }
}
