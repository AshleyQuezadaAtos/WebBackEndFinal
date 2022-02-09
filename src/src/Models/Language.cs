using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebCourseRepo.Models
{
    public class Language : Entity
    {
       
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public char Lang { get; set; }

    }
}
