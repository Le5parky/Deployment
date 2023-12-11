using Deployment.DomainModel.Managers.Interfaces;
using Deployment.Dto;

namespace Deployment.WebApp.Services;

public class ApplicationService
{
    private readonly IApplicationManager _applicationManager;

    public ApplicationService(IApplicationManager applicationManager)
    {
        _applicationManager = applicationManager;
    }

    public async Task<IEnumerable<ApplicationDto>> GetApplication()
    {
        return await _applicationManager.GetApplications();
    }

    public async Task<ApplicationDto> GetApplicationById(int appId)
    {
        return await _applicationManager.GetApplicationById(appId);


    }

    public async Task<ApplicationDto> GetApplicationByCode(string code)
    {
        return await _applicationManager.GetApplicationByCode(code);
    }
}