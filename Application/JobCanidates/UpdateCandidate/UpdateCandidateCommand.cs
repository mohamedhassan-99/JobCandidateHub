using Application.Abstractions.Messaging;

namespace Application.JobCanidates.UpdateCandidate;

public record UpdateCandidateCommand(Guid Id,
                                     string FirstName,
                                     string LastName,
                                     string PhoneNumber,
                                     string Email,
                                     TimeOnly CallFrom,
                                     TimeOnly CallTo,
                                     string LinkedIn,
                                     string GitHub,
                                     string Comment) : ICommand<Guid>;
