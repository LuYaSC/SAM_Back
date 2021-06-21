using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAM.Functions.ResolveCasesSiver.Business;
using SAM.Functions.ResolveCasesSiver.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResolveCaseContribution.MicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class ResolveCaseSiverController : ControllerBase
    {
        private readonly ILogger<ResolveCaseSiverController> _logger;
        IResolveDiferenceBusiness business;

        public ResolveCaseSiverController(ILogger<ResolveCaseSiverController> logger, IResolveDiferenceBusiness business)
        {
            _logger = logger;
            this.business = business;
        }

        [HttpPost]
        public ResolveDiferenceResult GetCaseData([FromBody] ResolveDiferenceDto dto) => business.GetCaseData(dto);

        [HttpPost]
        public ResolveDiferenceResult GetCaseDataBC([FromBody] ResolveDiferenceDto dto) => business.GetCaseDataBC(dto);

        [HttpPost]
        public List<ResolveDiferenceMassiveResult> GetCaseDataMassive([FromBody] ResolveDiferenceDto dto) => business.GetCaseDataMassive(dto);

        [HttpPost]
        public GetPassiveAportsResponse UnificationPassiveAports([FromBody] GetPassiveAportsDto dto) => business.UnificationPassiveAports(dto);

        [HttpPost]
        public ResolveDiferenceMassiveResult CompletePassiveAports(GetPassiveAportsDto dto) => business.CompletePassiveAports(dto);

        [HttpPost]
        public List<ResolveDiferenceMassiveResult> CompleteMassivePassiveAports(GetPassiveAportsDto dto) => business.CompleteMassivePassiveAports(dto);

    }
}
