using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCourseRepo.Configurations;
using WebCourseRepo.Models;

namespace WebCourseRepo.Repositories.Implementation
{
    public class TopicRepository : ITopicRepository
    {
        private readonly EntityContext _entityContext;

        public TopicRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<List<Topic>> FindAll()
        {
            return await _entityContext.Topics.ToListAsync();
        }

        public async Task<Topic?> FindById(int id)
        {
            return await _entityContext.Topics.FindAsync(id);
        }

        public void Insert(Topic status)
        {
            _entityContext.Topics.Add(status);
        }

        public async Task Delete(int id)
        {
            Topic? toDelete = await FindById(id);
            _entityContext.Topics.Remove(toDelete!);
        }

        public void Update(Topic status)
        {
            _entityContext.Topics.Update(status);
        }

        public async Task<int> Save()
        {
            return await _entityContext.SaveChangesAsync();
        }

    }
}