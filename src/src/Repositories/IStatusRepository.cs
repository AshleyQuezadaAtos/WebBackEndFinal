using System.Collections.Generic;
using System.Threading.Tasks;
using WebCourseRepo.Models;

namespace WebCourseRepo.Repositories
{
    public interface IStatusRepository
    {
        Task<List<Status>> FindAll();
        Task<Status?> FindById(int id);
        void Insert(Status Status);
        Task Delete(int id);
        void Update(Status Status);
        Task<int> Save();
    }
}