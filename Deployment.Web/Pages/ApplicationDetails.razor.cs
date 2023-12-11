using Deployment.Dto;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Deployment.Web.Pages
{
    public partial class ApplicationDetails
    {
        [Parameter] 
        public string Code { get; set; }

        public ApplicationDto _application;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
