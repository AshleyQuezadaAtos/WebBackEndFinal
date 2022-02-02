using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebCourseRepo.Dtos;
using WebCourseRepo.Models;
using WebCourseRepo.Services;

namespace WebCourseRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController :ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        //Get: api/Course
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CourseDto> course = await _courseService.FindAll();
            return Ok(course);
        }
        //Get api/Course/Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            CourseDto? courseDto = await _courseService.FindById(id);
            return courseDto != null ? Ok(courseDto) : NotFound();
        }

        //Post create
        [HttpPost]
        public async Task<IActionResult> Create(CourseDto courseDto)
        {
            try
            {
                await _courseService.Insert(courseDto);
                return Created(Request.GetDisplayUrl(), courseDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        //Put update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseDto courseDto)
        {
            if (id != courseDto.Id) return BadRequest();
            _courseService.Update(courseDto);
            return NoContent();
        }
    }
}
