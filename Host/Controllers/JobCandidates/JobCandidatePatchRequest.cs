namespace Host.Controllers.JobCandidates;

public record JobCandidatePatchRequest
{
    public Guid? Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public TimeOnly CallFrom { get; set; }
    public TimeOnly CallTo { get; set; }
    public string LinkedIn { get; init; }
    public string GitHub { get; init; }
    public string Comment { get; init; }
}
