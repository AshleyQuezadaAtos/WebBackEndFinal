using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebCourseRepo.Dtos;
using WebCourseRepo.Models;
using WebCourseRepo.Repositories;
using WebCourseRepo.Services;

namespace WebStatusRepo.Services.Implementation
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusService(IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<List<StatusDto>> FindAll()
        {
            List<Status> status = await _statusRepository.FindAll();
            return _mapper.Map<List<Status>,List<StatusDto>>(status);
        }

        public async Task<StatusDto?> FindById(int id)
        {
            Status? status = await _statusRepository.FindById(id);
            return status == null 
                ? null 
                : _mapper.Map<Status, StatusDto>(status);
        }

        public async Task Insert(StatusDto statusDto)
        {
            Status status = _mapper.Map<StatusDto, Status>(statusDto);
            _statusRepository.Insert(status);
            await Save();
        }

        public async Task Delete(int id)
        {
            await _statusRepository.Delete(id);
            await _statusRepository.Save();
        }

        public void Update(StatusDto statusDto)
        {
            Status status = _mapper.Map<StatusDto, Status>(statusDto);
            _statusRepository.Update(status);
        }

        public async Task<int> Save()
        {
            return await _statusRepository.Save();
        }
    }
}