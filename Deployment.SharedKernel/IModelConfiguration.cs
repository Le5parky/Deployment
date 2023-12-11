using Microsoft.EntityFrameworkCore;

namespace Deployment.SharedKernel
{
    public interface IModelConfiguration
    {
        void ConfigureModel(ModelBuilder modelBuilder);
    }
}