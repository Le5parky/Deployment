using Microsoft.AspNetCore.Components;
using Deployment.Dto;

namespace Deployment.Web.Components
{
    public partial class AppCard
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public ApplicationDto Application { get; set; }

        private ApplicationDto _application;

        protected override Task OnInitializedAsync()
        {
            base.OnInitialized();

            _application = Application ?? new ApplicationDto();

            return Task.FromResult(_application);
        }

        private void HandleCellClickDetails(string code)
        {
            NavigationManager.NavigateTo($"/details/{code}");
        }
        private void HandleCellClick(string code)
        {
            NavigationManager.NavigateTo($"/application/{code}");
        }
    }
}
