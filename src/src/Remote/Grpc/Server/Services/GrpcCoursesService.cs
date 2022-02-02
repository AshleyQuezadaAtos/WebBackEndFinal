
using api.Grpc;
using AutoMapper;
using Grpc.Core;
using WebCourseRepo.Dtos;
using WebCourseRepo.Services;

namespace WebBackEndRepo.Remote.Grpc.Server.Services;

public class GrpcCoursesService : GrpcCourses.GrpcCoursesBase
{
    private readonly ICourseService _service;
    private readonly IMapper _mapper;

    public GrpcCoursesService(ICourseService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    //Retorna los cursos de un usuario
    // ---/user/{userId
    public override async Task<GetByIdsResponse> GetByIds(GetByIdsRequest request, ServerCallContext context)
    {
        GetByIdsResponse response = new GetByIdsResponse();
        List<CourseDto> dtos = await _service.FindByIds(request.Ids.ToList());
        foreach (var dto in dtos)
        {
            response.Courses.Add(
                _mapper.Map<CourseDto, Course>(dto)
                );
        }
        return response;
    }

   

    //Retorna los cursos de un usuario
    // ---/user/{userId}/course/{courseId}
    public override async Task<GetByIdsCourseUserResponse> GetByIdsCourseUser(GetByIdsCourseUserRequest request, ServerCallContext context)
    {
        GetByIdsCourseUserResponse response = new GetByIdsCourseUserResponse();
        CourseDto dtos = await _service.FindById(request.Id);
        
            response.CoursesDetails=_mapper.Map<CourseDto, CourseDetails>(dtos);
        
        return response;
    }

}