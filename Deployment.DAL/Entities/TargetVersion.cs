namespace Deployment.DAL.Entities;

public class TargetVersion:BaseEntity
{
    public int TargetVersionId { get; set; }
    public int Major { get; set; }
    public int Minot { get; set; }
    public int Build { get; set; }
    public string Lable { get; set; }
    public Application Application { get; set; }
}