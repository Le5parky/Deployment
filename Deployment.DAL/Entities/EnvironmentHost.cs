using Microsoft.EntityFrameworkCore.Storage;

namespace Deployment.DAL.Entities;

public class EnvironmentHost : BaseEntity
{
    public int EnvironmentHostId { get; set; }
    public Host Host { get; set; }

}