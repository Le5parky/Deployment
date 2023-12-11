namespace Deployment.Dto
{
    public class ApplicationDto
    {

        public ApplicationDto()
        {
            Environments = new List<EnvironmentDto>();
        }
        public int ApplicationId { get; set; }
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Tag { get; set; } = default!;
        public string DropZone { get; set; } = default!;
        public string MailTo { get; set; } = default!;
        public string MailCC { get; set; } = default!;
        public ICollection<EnvironmentDto> Environments { get; set; }
    }
}