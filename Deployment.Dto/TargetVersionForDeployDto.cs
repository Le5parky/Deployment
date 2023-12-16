using System.Globalization;

namespace Deployment.Dto;

public class TargetVersionForDeployDto{

    public string Name{get;set;} = default!;
    public bool IsDeployble{get;set;}
    public string Author {get;set;} = default!;
    public string Revision {get;set;} = default!;
    public string DateTime{get;set;} = default!;
    public string SoursePath {get;set;} = default!;
    public bool MarkBuild{get;set;}
}
