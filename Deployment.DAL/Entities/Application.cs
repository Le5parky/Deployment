using System.Globalization;
using System.Reflection.PortableExecutable;

namespace Deployment.DAL.Entities;

public class Application: BaseEntity
{
    public int ApplicationId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Tag { get; set; }
    public string DropZone { get; set; }
    public string MailTo { get; set; }
    public string MailCC { get; set; }
    public ICollection<Environment> Environments { get; set; }
}