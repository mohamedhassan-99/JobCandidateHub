using Application.JobCanidates.CreateCandidate;
using Application.JobCanidates.GetCandidates;
using Application.JobCanidates.UpdateCandidate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers.JobCandidates;

[Route("api/[controller]")]
[ApiController]
public class JobCandidateController(ISender sender) : ControllerBase
{
    [HttpGet]
    public IActionResult GetCandidates()
    {
        var candidates = sender.Send(new GetCandidatesQuery());

        return Ok(candidates);
    }

    [HttpPatch]
    public IActionResult CreateOrUpdateCandidates(JobCandidatePatchRequest request)
    {
        if (request.Id == null || request.Id == Guid.Empty)
        {
            var result = sender.Send(new CreateCandidateCommand(request.FirstName,
                                                                request.LastName,
                                                                request.PhoneNumber,
                                                                request.Email,
                                                                request.CallTo,
                                                                request.CallFrom,
                                                                request.LinkedIn,
                                                                request.GitHub,
                                                                request.Comment));

            return Ok(result);
        }
        else
        {
            var result = sender.Send(new UpdateCandidateCommand(request.Id.Value,
                                                                request.FirstName,
                                                                request.LastName,
                                                                request.PhoneNumber,
                                                                request.Email,
                                                                request.CallTo,
                                                                request.CallFrom,
                                                                request.LinkedIn,
                                                                request.GitHub,
                                                                request.Comment));

            return Ok(result);
        }

    }
}
