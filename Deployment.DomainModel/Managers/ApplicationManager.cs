using AutoMapper;
using Deployment.DAL.Repositories;
using Deployment.DomainModel.Managers.Interfaces;
using Deployment.Dto;

namespace Deployment.DomainModel.Managers;

public class ApplicationManager : IApplicationManager
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ApplicationDto>> GetApplications()
    {
        var app = await _applicationRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ApplicationDto>>(app);
    }

    public async Task<ApplicationDto> GetApplicationById(int appId)
    {
        var app = await _applicationRepository.GetByIdAsync(appId);
        return _mapper.Map<ApplicationDto>(app);
    }

    public async Task<ApplicationDto> GetApplicationByCode(string code)
    {
        var app = await _applicationRepository.GetAllAsync();
        var result = app.SingleOrDefault(x => x.Code == code);
        return _mapper.Map<ApplicationDto>(result);
    }
}
