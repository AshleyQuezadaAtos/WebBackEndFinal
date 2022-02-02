using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebCourseRepo.Dtos;
using WebCourseRepo.Models;
using WebCourseRepo.Repositories;
using WebCourseRepo.Services;

namespace WebTopicRepo.Services.Implementation
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public TopicService(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<List<TopicDto>> FindAll()
        {
            List<Topic> topic = await _topicRepository.FindAll();
            return _mapper.Map<List<Topic>,List<TopicDto>>(topic);
        }

        public async Task<TopicDto?> FindById(int id)
        {
            Topic? topic = await _topicRepository.FindById(id);
            return topic == null 
                ? null 
                : _mapper.Map<Topic, TopicDto>(topic);
        }

        public async Task Insert(TopicDto topicDto)
        {
            Topic topic = _mapper.Map<TopicDto, Topic>(topicDto);
            _topicRepository.Insert(topic);
            await Save();
        }

        public async Task Delete(int id)
        {
            await _topicRepository.Delete(id);
            await _topicRepository.Save();
        }

        public void Update(TopicDto topicDto)
        {
            Topic topic = _mapper.Map<TopicDto, Topic>(topicDto);
            _topicRepository.Update(topic);
        }

        public async Task<int> Save()
        {
            return await _topicRepository.Save();
        }
    }
}