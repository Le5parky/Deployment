namespace Deployment.DAL.Entities;

public class Team : BaseEntity
{
    public int TeamId { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public ICollection<User> Users { get; set; }
}