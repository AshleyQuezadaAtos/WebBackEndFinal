
using api.Grpc;
using AutoMapper;
using Grpc.Core;
using WebCourseRepo.Dtos;
using WebCourseRepo.Services;

namespace WebBackEndRepo.Remote.Grpc.Server.Services;

public class GrpcTopicService : GrpcTopics.GrpcTopicsBase
{
    private readonly ITopicService _service;
    private readonly IMapper _mapper;

    public GrpcTopicService(ITopicService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    

    //Retorna los cursos de un usuario
    // ---/user/{userId}/topic/{topicId}
    public override async Task<GetByIdsTopicUserResponse> GetByIdsTopicUser(GetByIdsTopicUserRequest request, ServerCallContext context)
    {
        GetByIdsTopicUserResponse response = new GetByIdsTopicUserResponse();
        TopicDto dtos = await _service.FindById(request.Id);

        response.TopicsDetails = _mapper.Map<TopicDto, TopicsDetails>(dtos);

        return response;
    }


}