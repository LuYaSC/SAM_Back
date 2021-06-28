using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAM.Core.Business;
using SAM.Functions.Investments.ReturnsASR.Business;
using SAM.Functions.Investments.ReturnsASR.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ReturnsASR.MicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[Authorize]

    public class ReturnsASRController : ControllerBase
    {
        private readonly ILogger<ReturnsASRController> _logger;
        IReturnsASRBusiness business;

        public ReturnsASRController(ILogger<ReturnsASRController> logger, IReturnsASRBusiness business)
        {
            _logger = logger;
            this.business = business;
        }

        [HttpPost]
        public Result<List<GetReturnsASRResult>> GetReturnsASR() => business.GetReturnsASR();

        [HttpPost]
        public Result<GetBeneficiaryResult> GetBeneficiary([FromBody] GetBeneficiaryDto dto) => business.GetBeneficiary(dto);

        [HttpPost]
        public Result<string> RegistryReturnASR([FromBody] RegistryReturnASRDto dto) => business.RegistryReturnASR(dto);

        [HttpPost]
        public Result<string> ModifyRegistryASR([FromBody] ModifyRegistryASRDto dto) => business.ModifyRegistryASR(dto);

        [HttpPost]
        public Result<string> Delete([FromBody] ModifyRegistryASRDto dto) => business.Delete(dto);
    }
}
