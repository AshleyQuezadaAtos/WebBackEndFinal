using System.Collections.Generic;
using System.Threading.Tasks;
using WebCourseRepo.Dtos;
using WebCourseRepo.Models;

namespace WebCourseRepo.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> FindAll();
        Task<CourseDto?> FindById(int id);
        
        Task<List<CourseDto>> FindByIds(List<int> ids);
        Task Insert(CourseDto course);
        Task Delete(int id);
        void Update(CourseDto course);
        Task<int> Save();
    }
}