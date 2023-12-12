using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoverCandidate.Domain.WatchHands;
using System;

namespace MoverCandidateTest.Controllers.WatchHands
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateLeastAngleController : ControllerBase
    {
        private readonly ILogger<CalculateLeastAngleController> _logger;

        public CalculateLeastAngleController(ILogger<CalculateLeastAngleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery] CalculateLeastAngleRequestModel requestModel)
        {
            var time = requestModel.DateTime;
            var leastAngel = (new LeastAngelService()).FindLeastAngel(time);
            return leastAngel.ToString();
            
        }
    }
}
