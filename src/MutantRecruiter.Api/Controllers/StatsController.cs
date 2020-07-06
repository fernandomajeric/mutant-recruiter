using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MutantRecruiter.Api.Models;
using MutantRecruiter.Core.Interfaces;
using Newtonsoft.Json;

namespace MutantRecruiter.Api.Controllers
{
    [Route("api/stats")]
    public class StatsController : BaseApiController
    {
        private readonly ILogger<StatsController> _logger;
        private readonly IStatsService _service;

        public StatsController(ILogger<StatsController> logger, IStatsService stateService)
        {
            _logger = logger;
            _service = stateService;
        }

        [HttpGet]
        public ActionResult<StatsModel> Get()
        {
            try
            {
                this._logger.LogDebug("Stats - Get");

                var result = this._service.GetStats();

                this._logger.LogDebug(JsonConvert.SerializeObject(result));

                return Ok(StatsModel.ToModel(result));
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
