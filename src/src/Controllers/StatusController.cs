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
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        //Get: api/Course
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<StatusDto> status = await _statusService.FindAll();
            return Ok(status);
        }
        //Get api/Course/Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            StatusDto? statusDto = await _statusService.FindById(id);
            return statusDto != null ? Ok(statusDto) : NotFound();
        }

        //Post create
        [HttpPost]
        public async Task<IActionResult> Create(StatusDto statusDto)
        {
            try
            {
                await _statusService.Insert(statusDto);
                return Created(Request.GetDisplayUrl(), statusDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        //Put update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StatusDto statusDto)
        {
            if (id != statusDto.Id) return BadRequest();
            _statusService.Update(statusDto);
            return NoContent();

        }
    }
}
