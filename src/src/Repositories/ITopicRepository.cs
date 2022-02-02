using System.Collections.Generic;
using System.Threading.Tasks;
using WebCourseRepo.Models;

namespace WebCourseRepo.Repositories
{
    public interface ITopicRepository
    {
        Task<List<Topic>> FindAll();
        Task<Topic?> FindById(int id);
        void Insert(Topic Topic);
        Task Delete(int id);
        void Update(Topic Topic);
        Task<int> Save();
    }
}