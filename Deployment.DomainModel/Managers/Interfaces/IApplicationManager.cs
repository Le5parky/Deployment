using Deployment.Dto;

namespace Deployment.DomainModel.Managers.Interfaces;

public interface IApplicationManager
{
    public Task<IEnumerable<ApplicationDto>> GetApplications();
    public Task<ApplicationDto> GetApplicationById(int appId);
    public Task<ApplicationDto> GetApplicationByCode(string code);
}