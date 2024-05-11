using Application.JobCanidates.CreateCandidate;
using Application.JobCanidates.GetCandidatesPage;
using Application.JobCanidates.UpdateCandidate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers.JobCandidates;

[Route("api/[controller]")]
[ApiController]
public class JobCandidateController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCandidates(int pageNo = 0, int pageSize = 10)
    {
        var result = await sender.Send(new GetCandidatesPageQuery(pageNo, pageSize));

        return Ok(result.Value);
    }

    [HttpPatch]
    public async Task<IActionResult> CreateOrUpdateCandidates(JobCandidatePatchRequest request)
    {
        if (request.Id == null || request.Id == Guid.Empty)
        {
            var result = await sender.Send(new CreateCandidateCommand(request.FirstName,
                                                                      request.LastName,
                                                                      request.PhoneNumber,
                                                                      request.Email,
                                                                      request.CallTo.GetValueOrDefault(),
                                                                      request.CallFrom.GetValueOrDefault(),
                                                                      request.LinkedIn,
                                                                      request.GitHub,
                                                                      request.Comment));

            return Ok(result.Value);
        }
        else
        {
            var result = await sender.Send(new UpdateCandidateCommand(request.Id.Value,
                                                                      request.FirstName,
                                                                      request.LastName,
                                                                      request.PhoneNumber,
                                                                      request.Email,
                                                                      request.CallTo.GetValueOrDefault(),
                                                                      request.CallFrom.GetValueOrDefault(),
                                                                      request.LinkedIn,
                                                                      request.GitHub,
                                                                      request.Comment));

            return Ok(result.Value);
        }

    }
}
