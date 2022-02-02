using System.Collections.Generic;
using System.Threading.Tasks;
using WebCourseRepo.Dtos;
using WebCourseRepo.Models;

namespace WebCourseRepo.Services
{
    public interface IStatusService
    {
        Task<List<StatusDto>> FindAll();
        Task<StatusDto?> FindById(int id);
        Task Insert(StatusDto status);
        Task Delete(int id);
        void Update(StatusDto status);
        Task<int> Save();
    }
}