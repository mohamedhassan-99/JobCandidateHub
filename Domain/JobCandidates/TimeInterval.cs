namespace Domain.JobCandidates;

public record TimeInterval
{
    private TimeInterval() { }
    public TimeOnly From { get; set; }
    public TimeOnly To { get; set; }

    public static TimeInterval Create(TimeOnly from, TimeOnly to)
    {
        if (from < to)
            throw new ApplicationException("from time precedes to time");

        return new TimeInterval
        {
            From = from,
            To = to
        };
    }
}