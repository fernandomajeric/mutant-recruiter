using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MutantRecruiter.Api.Models;
using MutantRecruiter.Core.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MutantRecruiter.Api.Controllers
{
    [Route("api/mutant")]
    public class RecruitmentController : BaseApiController
    {
        private readonly IRecruitmentService service;
        private readonly ILogger<RecruitmentController> _logger;

        public RecruitmentController(IRecruitmentService service, ILogger<RecruitmentController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Recruit(RecruitModel model)
        {
            try
            {
                this._logger.LogDebug("mutant: {0}", JsonConvert.SerializeObject(model));

                if (model == null)
                    return BadRequest("model empty");

                var result = await this.service.Recruit(model.Dna);

                this._logger.LogDebug("Is Mutant: {}", result);

                if (!result)
                    return StatusCode(StatusCodes.Status403Forbidden);

                return Ok();
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}