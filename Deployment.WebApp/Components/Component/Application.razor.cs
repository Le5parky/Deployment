using Deployment.Dto;
using Microsoft.AspNetCore.Components;

namespace Deployment.WebApp.Components.Component
{
    public partial class Application
    {
        [Parameter]
        public string Code { get; set; }


        private ApplicationDto _application;

        protected override async Task OnInitializedAsync()
        {
            _application = await ApplicationService.GetApplicationByCode(Code);
        }

        private EnvironmentDto Environment { get; set; }
    }
}
