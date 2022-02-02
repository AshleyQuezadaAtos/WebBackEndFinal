using AutoMapper;
using WebCourseRepo.Dtos;
using WebCourseRepo.Models;

namespace WebCourseRepo.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //source -> Target
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();

            
            //Dto -> Grpc
            CreateMap<CourseDto, api.Grpc.Course>();
        }
    }
}