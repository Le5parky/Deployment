using Deployment.Dto;
using Deployment.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace Deployment.WebApp.Components.Pages
{
    public partial class AppList
    {
        [Inject]
        public ApplicationService ApplicationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private IEnumerable<ApplicationDto> _applications;

        protected override async Task OnInitializedAsync()
        {
            _applications = await ApplicationService.GetApplication();
        }
    }
}
