using Deployment.Common.Configuration;
using Deployment.DAL.Entities;
using Deployment.DAL.Repositories;
using Deployment.DomainModel.Managers.Interfaces;
using Deployment.Dto;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Deployment.Web.Data;

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