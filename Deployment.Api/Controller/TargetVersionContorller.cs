namespace Deployment.Api;

public interface ITargetVersionContorller
{
    TargetVersion[] GetTargetVersions(); 
}

public class TargetVersionContorller : ITargetVersionContorller
{
    public TargetVersion[] GetTargetVersions()
    {
        var versions  = new [] {new TargetVersion("0.0.1"), new TargetVersion("0.0.2"),new TargetVersion("0.0.3")};
       return versions;
    }
}
