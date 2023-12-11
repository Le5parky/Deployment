using AutoMapper;
using Deployment.DAL.Entities;
using Deployment.Dto;

namespace Deployment.Infrastructure.Automapper;

public class ApplicationMapping: Profile
{
    public ApplicationMapping()
    {
        CreateMap<Application, ApplicationDto>()
            .ForMember(x => x.Environments, scr => scr.Ignore());
    }
}