namespace Deployment.DAL.Entities;

public class Host : BaseEntity
{
    

    public int HostId { get; set; }
    public string FQDN { get; set; }
    public string Alias { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public string OS { get; set; }
    public string Description { get; set; }
}