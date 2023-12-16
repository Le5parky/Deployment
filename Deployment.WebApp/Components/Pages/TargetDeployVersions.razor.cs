using Deployment.Dto;
using Microsoft.AspNetCore.Components;

namespace Deployment.WebApp.Components.Pages
{
    public partial class TargetDeployVersions
    {

        [Parameter]
        public string Code { get; set; }
        public ApplicationDto Application { get; set; }
        public IList<TargetVersionDto> TargetVersions { get; set; }
        public IQueryable<TargetVersionDto> TargetVersions2 { get; set; }
        public TargetVersionDto TargetVersion{get;set;}
        public EnvironmentDto Environment {get;set;}
        public IQueryable<DeployedVersionDto> DeployedVersion{get;set;} 
        
        protected override Task OnInitializedAsync()
        {
            TargetVersions = new List<TargetVersionDto>(){
                new TargetVersionDto { Major = 0, Minot = 0, Build = 1},
                new TargetVersionDto { Major = 0, Minot = 0, Build = 2},
                new TargetVersionDto { Major = 0, Minot = 0, Build = 3}
            }.OrderByDescending(x=>x.Major).ThenByDescending(x=>x.Minot).ThenByDescending(x=>x.Build).ToList();
            
            TargetVersions2 = new TargetVersionDto[]
            {
                new TargetVersionDto { Major = 0, Minot = 0, Build = 1},
                new TargetVersionDto { Major = 0, Minot = 0, Build = 2},
                new TargetVersionDto { Major = 0, Minot = 0, Build = 3}
            }.AsQueryable();
          
            DeployedVersion = new DeployedVersionDto[]
            {
                new DeployedVersionDto{Environment = "DEV", Version="0.0.1", Status = "OK"},
                new DeployedVersionDto{Environment = "ITT", Version="0.0.1", Status = "OK"},
                new DeployedVersionDto{Environment = "UAT", Version="0.0.2", Status = "OK"},
                new DeployedVersionDto{Environment = "PROD", Version="0.0.3", Status = "OK"},
            }.AsQueryable();


            Application = new ApplicationDto();
            Application.Environments.Add(new EnvironmentDto{Name ="DEV"});
            Application.Environments.Add(new EnvironmentDto{Name ="ITT"});
            Application.Environments.Add(new EnvironmentDto{Name ="UAT"});
            Application.Environments.Add(new EnvironmentDto{Name ="PROD"});

            Environment = Application.Environments.FirstOrDefault(x=>x.Name.Equals("Dev", StringComparison.InvariantCultureIgnoreCase));
            TargetVersion = TargetVersions.FirstOrDefault();
      

            return base.OnInitializedAsync();
        }
    }
}
