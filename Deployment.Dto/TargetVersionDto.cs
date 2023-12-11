namespace Deployment.Dto;

public class TargetVersionDto
{
    public int TargetVersionId { get; set; }
    public int Major { get; set; }
    public int Minot { get; set; }
    public int Build { get; set; }
    public string Lable { get; set; } = default!;
    public ApplicationDto Application { get; set; } = default!;

    public string DisplayValue()
    {
        return $"{Major}.{Minot}.{Build}";
    }
}