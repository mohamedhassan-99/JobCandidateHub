using Application.Abstractions.Messaging;
using Domain.Common.Contract;
using Domain.JobCandidates;

namespace Application.JobCanidates.CreateCandidate;

public class CreateOrUpdateCandidateCommandHandler(IJobCandidateRepository repository,
                                                   IUnitOfWork unitOfWork) : ICommandHandler<CreateCandidateCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {

        var candidate = JobCandidate.Create(new(request.FirstName),
                                            new(request.LastName),
                                            new(request.PhoneNumber),
                                            new(request.Email),
                                            TimeInterval.Create(request.CallFrom, request.CallTo),
                                            new(request.LinkedIn),
                                            new(request.GitHub),
                                            new(request.Comment));

        repository.Add(candidate);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return candidate.Id.Value;
    }
}
