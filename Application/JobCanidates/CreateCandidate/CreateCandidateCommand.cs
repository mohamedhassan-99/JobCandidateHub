using Application.Abstractions.Messaging;

namespace Application.JobCanidates.CreateCandidate;

public record CreateCandidateCommand(string FirstName,
                                     string LastName,
                                     string PhoneNumber,
                                     string Email,
                                     TimeOnly CallFrom,
                                     TimeOnly CallTo,
                                     string LinkedIn,
                                     string GitHub,
                                     string Comment) : ICommand<Guid>;
