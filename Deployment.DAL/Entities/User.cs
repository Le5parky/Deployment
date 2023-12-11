namespace Deployment.DAL.Entities;

public class User : BaseEntity
{
    public int UserId { get; set; }
    public string PerId { get; set; }
    public Application DefApplication { get; set; }
    public Team Team { get; set; }
}