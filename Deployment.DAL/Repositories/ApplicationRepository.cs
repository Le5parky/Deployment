using Deployment.DAL.Entities;
using Deployment.DAL.Repositories.Interface;

namespace Deployment.DAL.Repositories;


public interface IApplicationRepository : IRepository<Application>
{
}

public class ApplicationRepository:AbstractRepository<Application>, IApplicationRepository
{
    public ApplicationRepository(DeploymentDbContext context) : base(context)
    {
        
    }
}