using System.Collections.Generic;
using System.Threading.Tasks;
using WebCourseRepo.Dtos;
using WebCourseRepo.Models;

namespace WebCourseRepo.Services
{
    public interface ITopicService
    {
        Task<List<TopicDto>> FindAll();
        Task<TopicDto?> FindById(int id);
        Task Insert(TopicDto topic);
        Task Delete(int id);
        void Update(TopicDto topic);
        Task<int> Save();
    }
}