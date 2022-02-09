using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebCourseRepo.Dtos;
using WebCourseRepo.Models;
using WebCourseRepo.Repositories;

namespace WebCourseRepo.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

     

        public async Task<List<CourseDto>> FindAll()
        {
            List<Course> course = await _courseRepository.FindAll();
            return _mapper.Map<List<Course>,List<CourseDto>>(course);
        }

        public async Task<CourseDto?> FindById(int id)
        {
            Course? course = await _courseRepository.FindById(id);
            return course == null ? null : _mapper.Map<Course, CourseDto>(course);
        }

        public async Task<CourseDetailsDto?> FindByIdDetails(int id)
        {
            Course? course = await _courseRepository.FindById(id);
            return course == null ? null : _mapper.Map<Course, CourseDetailsDto>(course);
        }

        public async Task<List<CourseDto>> FindByIds(List<int> ids)
        {
            List<Course> courses = await _courseRepository.FindByIds(ids);
            return _mapper.Map<List<Course>, List<CourseDto>>(courses);
        }

        public async Task Insert(CourseDto courseDto)
        {
            Course course = _mapper.Map<CourseDto, Course>(courseDto);
            _courseRepository.Insert(course);
            await Save();
        }

        public async Task Delete(int id)
        {
            await _courseRepository.Delete(id);
            await _courseRepository.Save();
        }

        public void Update(CourseDto courseDto)
        {
            Course course = _mapper.Map<CourseDto, Course>(courseDto);
            _courseRepository.Update(course);
        }

        public async Task<int> Save()
        {
            return await _courseRepository.Save();
        }
    }
}