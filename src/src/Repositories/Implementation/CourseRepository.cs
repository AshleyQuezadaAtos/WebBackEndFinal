using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCourseRepo.Configurations;
using WebCourseRepo.Models;

namespace WebCourseRepo.Repositories.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly EntityContext _entityContext;

        public CourseRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<List<Course>> FindAll()
        {
            return await _entityContext.Courses.ToListAsync();
        }

        public async Task<Course?> FindById(int id)
        {
            return await _entityContext.Courses.FindAsync(id);
        }
        
        public async Task<List<Course>> FindByIds(List<int> ids) //TODO: Validar posibles errores.
        {
            var query = _entityContext.Courses.Where(entity => ids.Contains(entity.Id));
            Console.WriteLine(query.ToQueryString());                
            return await query.ToListAsync();
        }

        public void Insert(Course course)
        {
            _entityContext.Courses.Add(course);
        }

        public async Task Delete(int id)
        {
            Course? toDelete = await FindById(id);
            _entityContext.Courses.Remove(toDelete!);
        }

        public void Update(Course course)
        {
            _entityContext.Courses.Update(course);
        }

        public async Task<int> Save()
        {
            return await _entityContext.SaveChangesAsync();
        }

    }
}