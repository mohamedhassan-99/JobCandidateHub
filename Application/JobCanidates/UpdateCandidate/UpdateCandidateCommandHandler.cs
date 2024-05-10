using Application.Abstractions.Messaging;
using Application.Exceptions;
using Domain.Common.Contract;
using Domain.JobCandidates;

namespace Application.JobCanidates.UpdateCandidate;

public class UpdateCandidateCommandHandler(IJobCandidateRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateCandidateCommand, Guid>
{
    public async Task<Result<Guid>> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = await repository.GetByIdAsync(new(request.Id), cancellationToken);

        if (candidate == null)
            return Result.Failure<Guid>(Error.NotFound);

        try
        {
            candidate.Update(new(request.Id),
                 new(request.FirstName),
                 new(request.LastName),
                 new(request.PhoneNumber),
                 new(request.Email),
                 TimeInterval.Create(request.CallFrom, request.CallTo),
                 new(request.LinkedIn),
                 new(request.GitHub),
                 new(request.Comment));

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(Error.Concurrency);
        }

        return candidate.Id.Value;
    }
}
